using CriaderoDePollos.Entities;
using CriaderosDePollos.Abstactions;
using CriaderosDePollos.Entities;
using CriaderosDePollos.Entities.MicrosoftIdentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriaderosDePollos.DataAccess
{
    public class DbDataAccess : IdentityDbContext<User, Role, Guid>
    {
        public virtual DbSet<Pollos> Pollos { get; set; }
        public virtual DbSet<Galpones> Galpones { get; set; }
        public virtual DbSet<Conteodepollos> Conteodepollos { get; set; }
        public virtual DbSet<ControlDePeso> ControlDePeso { get; set; }
        public virtual DbSet<MantenimientoYEmergencias> MantenimientoYEmergencias { get; set; }
        public virtual DbSet<RetiroDePollos> RetiroDePollos { get; set; }
        public virtual DbSet<trabajador> Trabajadors { get; set; }
        public DbDataAccess(DbContextOptions<DbDataAccess> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine).EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var fk in modelBuilder.Model.GetEntityTypes()
                         .Where(t => typeof(IEntidad).IsAssignableFrom(t.ClrType))
                         .SelectMany(t => t.GetForeignKeys()))
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
