using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Dominio.ModuloFilme;
using GerenciadorDeCinema.Infra.Orm.Compartilhado;
using GerenciadorDeCinema.Infra.Orm.ModuloFilme;
using Microsoft.Extensions.Configuration;

namespace GerenciadorDeCinema.Dominio.Tests
{
    public class FilmeTest
    {

        [Test]
        public void nao_deve_validar_filme()
        {
            Filme filme = new("imagem", "", "descricao", new TimeSpan(1, 00, 47));

            ValidadorFilme validador = new();

            var result = validador.Validate(filme);

            Assert.IsFalse(result.IsValid);
            Assert.AreEqual("O campo título é obrigatório", result.Errors[0].ErrorMessage);
        }

        [Test]
        public void deve_validar_filme()
        {
            Filme filme = new("imagem", "titulo", "descricao", new TimeSpan(2, 25, 12));

            ValidadorFilme validador = new();

            var result = validador.Validate(filme);

            Assert.IsTrue(result.IsValid);
        }
    }
}