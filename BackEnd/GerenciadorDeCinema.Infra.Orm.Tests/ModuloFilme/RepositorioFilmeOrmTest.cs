using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Infra.Orm.Compartilhado;
using GerenciadorDeCinema.Infra.Orm.ModuloFilme;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace GerenciadorDeCinema.Infra.Orm.Tests.ModuloFilme
{
    public class Tests
    {
        private readonly GerenciadorDeCinemaDbContext db;

        public Tests()
        {
            //IConfiguration configuracao = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //var config = new GerenciadorDeCinemaAppConfig(configuracao);

            //db = new GerenciadorDeCinemaDbContext(config.ConnectionStrings);

            //db.Set<Filme>().RemoveRange(db.Set<Filme>());

            //db.SaveChanges();
        }

        [Test]
        public void Deve_inserir_filme()
        {
            //Filme novoFilme = new("fheuihfuhwf9h983yhfo", "Batman", "Pancadaria e suspense", "teste");
            //var repositorio = new RepositorioFilmeOrm(db);

            //repositorio.Inserir(novoFilme);
            //db.SaveChanges();

            //Filme filmeEncontrado = repositorio.SelecionarPorId(novoFilme.Id);

            //Assert.IsNotNull(filmeEncontrado);
        }
    }
}