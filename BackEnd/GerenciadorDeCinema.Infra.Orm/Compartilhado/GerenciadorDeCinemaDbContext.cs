using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Dominio.ModuloAutenticacao;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace GerenciadorDeCinema.Infra.Orm.Compartilhado
{
    public class GerenciadorDeCinemaDbContext: IdentityDbContext<Usuario, IdentityRole<Guid>, Guid>
    {
        public string connectionString;

        public GerenciadorDeCinemaDbContext(IConfiguration config)
        {
            //this.connectionString = config.GetConnectionString("SqlServer");
            this.connectionString = "Data Source=(LOCALDB)\\MSSQLLOCALDB;Initial Catalog=GerenciadorDeCinema;Integrated Security=True";
            Database.EnsureCreated();
        }

        public GerenciadorDeCinemaDbContext()
        {
            connectionString = "Data Source=(LOCALDB)\\MSSQLLOCALDB;Initial Catalog=GerenciadorDeCinema;Integrated Security=True";
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