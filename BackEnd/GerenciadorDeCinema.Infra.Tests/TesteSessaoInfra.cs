using GerenciadorDeCinema.Aplicacao.ModuloFilme;
using GerenciadorDeCinema.Aplicacao.ModuloSessao;
using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Dominio.ModuloSessao;
using GerenciadorDeCinema.Infra.Orm.Compartilhado;
using GerenciadorDeCinema.Infra.Orm.ModuloFilme;
using GerenciadorDeCinema.Infra.Orm.ModuloSessao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Infra.Tests
{
    public class TesteSessaoInfra
    {
        private ServicoSessao servicoSessao;
        private ServicoFilme servicoFilme;
        private RepositorioSessaoOrm repositorioSessao;
        private RepositorioFilmeOrm repositorioFilme;
        private GerenciadorDeCinemaDbContext dbContext;

        public TesteSessaoInfra()
        {
            dbContext = new();
            repositorioSessao = new(dbContext);
            servicoSessao = new(repositorioFilme, repositorioSessao, dbContext);

        }

        [Test]
        public void deve_inserir_a_entidade_no_banco()
        {
            Filme filme = new(
                "imagem teste",
                "titulo teste",
                "descricao teste",
                new TimeSpan(1, 30, 25)
                );

            servicoFilme.Inserir(filme);

            Sessao sessao = new();

            sessao.Data = DateTime.Now.AddDays(4);
            sessao.HorarioInicio = new(15, 35, 0);
            sessao.ValorIngresso = 5;
            sessao.TipoAnimacao = TipoAnimacao._3D;
            sessao.TipoAudio = TipoAudio.Original;
            sessao.FilmeId = filme.Id;
            sessao.SalaId = Guid.NewGuid().ToString();

            servicoSessao.Inserir(sessao);

            var sessaoBanco = servicoSessao.SelecionarPorId(sessao.Id);

            Assert.AreEqual(sessao.Id, sessaoBanco.Value.Id);

            servicoSessao.Excluir(sessao.Id);
            servicoFilme.Excluir(filme.Id);
        }

        [Test]
        public void deve_selecionar_todas_entidades_do_banco()
        {
            //Filme filme = new(
            //    "imagem teste",
            //    "titulo teste",
            //    "descricao teste",
            //    new TimeSpan(1, 30, 25)
            //    );

            //Filme filme2 = new(
            //    "imagem teste2",
            //    "titulo teste2",
            //    "descricao teste",
            //    new TimeSpan(5, 00, 15)
            //    );

            //Filme filme3 = new(
            //    "imagem teste3",
            //    "titulo teste3",
            //    "descricao teste",
            //    new TimeSpan(2, 45, 00)
            //    );

            //servicoFilme.Inserir(filme);
            //servicoFilme.Inserir(filme2);
            //servicoFilme.Inserir(filme3);

            //var filmes = servicoFilme.SelecionarTodos();

            //Assert.IsTrue(filmes.Value.Any(x => x.Id == filme.Id));
            //Assert.IsTrue(filmes.Value.Any(x => x.Id == filme2.Id));
            //Assert.IsTrue(filmes.Value.Any(x => x.Id == filme3.Id));

            //servicoFilme.Excluir(filme.Id);
            //servicoFilme.Excluir(filme2.Id);
            //servicoFilme.Excluir(filme3.Id);
        }
    }
}
