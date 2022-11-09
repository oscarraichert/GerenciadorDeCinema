﻿using GerenciadorDeCinema.Dominio.Filmes;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace GerenciadorDeCinema.Infra.Orm.Compartilhado
{
    public class GerenciadorDeCinemaDbContext: DbContext
    {
        private string connectionString;

        public GerenciadorDeCinemaDbContext(IConfiguration config)
        {
            this.connectionString = config.GetConnectionString("SqlServer");
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GerenciadorDeCinemaDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}