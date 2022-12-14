using GerenciadorDeCinema.Aplicacao.ModuloFilme;
using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Infra.Orm.Compartilhado;
using GerenciadorDeCinema.Infra.Orm.ModuloFilme;
using GerenciadorDeCinema.Infra.Orm.ModuloSessao;

namespace GerenciadorDeCinema.Infra.Tests
{
    public class Tests
    {
        private ServicoFilme servicoFilme;
        private RepositorioFilmeOrm repositorioFilme;
        private RepositorioSessaoOrm repositorioSessao;
        private GerenciadorDeCinemaDbContext dbContext;

        public Tests()
        {
            dbContext = new();
            repositorioFilme = new(dbContext);
            repositorioSessao = new(dbContext);
            servicoFilme = new(repositorioFilme, repositorioSessao, dbContext);
        }

        [Test]
        public void deve_inserir_a_entidade_no_banco()
        {
            Filme filme = new(
                "imagem testee",
                "titulo teste infra",
                "descricao teste",
                new TimeSpan(1, 30, 25)
                );

            servicoFilme.Inserir(filme);

            var filmeBanco = servicoFilme.SelecionarPorId(filme.Id);

            Assert.AreEqual(filme.Id, filmeBanco.Value.Id);

            servicoFilme.Excluir(filme.Id);
        }

        [Test]
        public void deve_selecionar_todas_entidades_do_banco()
        {
            Filme filme = new(
                "imagem teste",
                "titulo teste",
                "descricao teste",
                new TimeSpan(1, 30, 25)
                );

            Filme filme2 = new(
                "imagem teste2",
                "titulo teste2",
                "descricao teste",
                new TimeSpan(5, 00, 15)
                );

            Filme filme3 = new(
                "imagem teste3",
                "titulo teste3",
                "descricao teste",
                new TimeSpan(2, 45, 00)
                );

            servicoFilme.Inserir(filme);
            servicoFilme.Inserir(filme2);
            servicoFilme.Inserir(filme3);

            var filmes = servicoFilme.SelecionarTodos();

            Assert.IsTrue(filmes.Value.Any(x => x.Id == filme.Id));
            Assert.IsTrue(filmes.Value.Any(x => x.Id == filme2.Id));
            Assert.IsTrue(filmes.Value.Any(x => x.Id == filme3.Id));

            servicoFilme.Excluir(filme.Id);
            servicoFilme.Excluir(filme2.Id);
            servicoFilme.Excluir(filme3.Id);
        }
    }
}