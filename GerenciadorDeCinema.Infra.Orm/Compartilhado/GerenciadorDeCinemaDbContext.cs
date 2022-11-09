using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Infra.Config;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GerenciadorDeCinema.Infra.Orm.Compartilhado
{
    public class GerenciadorDeCinemaDbContext: DbContext
    {
        private string connectionString;

        public GerenciadorDeCinemaDbContext(ConnectionStrings connectionStrings)
        {
            this.connectionString = connectionStrings.SqlServer;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString);
        }
    }
}