using CriaderoDePollos.DataAccess;
using CriaderoDePollos.Repository;
using CriaderosDePollos.Abstactions;
using CriaderosDePollos.Application;
using CriaderosDePollos.DataAccess;
using CriaderosDePollos.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbDataAccess>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        o => o.MigrationsAssembly("Granja.WebApi"));
    options.UseLazyLoadingProxies();

});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped(typeof(IStringService), typeof(StringService));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IApplication<>), typeof(Application<>));
builder.Services.AddScoped(typeof(IDbContext<>), typeof(DbContext<>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
