using CriaderoDePollos.DataAccess;
using CriaderoDePollos.Repository;
using CriaderosDePollos.Abstactions;
using CriaderosDePollos.Application;
using CriaderosDePollos.DataAccess;
using CriaderosDePollos.Entities.MicrosoftIdentity;
using CriaderosDePollos.Services;
using CriaderosDePollos.Services.AuthServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// CORS: solo se permiten los origenes del frontend definidos en appsettings (Cors:AllowedOrigins)
const string FrontendCorsPolicy = "Frontend";
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(FrontendCorsPolicy, policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { 
c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema.De.pollos.WebApi", Version = "v1" });
var jwtSecurityScheme = new OpenApiSecurityScheme
{
    BearerFormat = "JWT",
    Name = "JWT Authentication",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = JwtBearerDefaults.AuthenticationScheme,
    Description = "Put your Token below",
    Reference = new OpenApiReference
    {
        Id = JwtBearerDefaults.AuthenticationScheme,
        Type = ReferenceType.SecurityScheme
    }
};
c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
c.AddSecurityRequirement(new OpenApiSecurityRequirement { { jwtSecurityScheme, Array.Empty<string>() } });
});


builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwt => {
    var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = false,
        ValidateLifetime = true
    };
});
builder.Services.AddIdentity<User, Role>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddDefaultTokenProviders()
.AddEntityFrameworkStores<DbDataAccess>()
.AddSignInManager<SignInManager<User>>()
.AddRoleManager<RoleManager<Role>>()
.AddUserManager<UserManager<User>>();

builder.Services.AddDbContext<DbDataAccess>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    o => o.MigrationsAssembly("CriaderosDePollos.WebApi"));
    options.UseLazyLoadingProxies();

});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped(typeof(IStringService), typeof(StringService));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IApplication<>), typeof(Application<>));
builder.Services.AddScoped(typeof(IDbContext<>), typeof(DbContext<>));

builder.Services.AddScoped<ITokenHandlerService, TokenHandlerService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Criaderos De Pollos API v1");

    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseCors(FrontendCorsPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
