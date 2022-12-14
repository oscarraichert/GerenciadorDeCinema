using GerenciadorDeCinema.Aplicacao.ModuloSessao;
using GerenciadorDeCinema.Dominio.ModuloFilme;
using GerenciadorDeCinema.Dominio.ModuloSessao;
using GerenciadorDeCinema.Infra.Orm.Compartilhado;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Dominio.Tests
{
    public class SessaoTest
    {
        [Test]
        public void nao_deve_validar_data_passada()
        {
            ValidadorSessao validador = new ValidadorSessao();

            Sessao sessao = new Sessao();

            sessao.Data = DateTime.Now.AddDays(-5);
            sessao.HorarioInicio = new(1, 30, 0);
            sessao.ValorIngresso = 5;
            sessao.TipoAnimacao = TipoAnimacao._3D;
            sessao.TipoAudio = TipoAudio.Original;
            sessao.FilmeId = Guid.NewGuid();
            sessao.SalaId = Guid.NewGuid();

            var resultado = validador.Validate(sessao);

            Assert.IsFalse(resultado.IsValid);
            Assert.AreEqual("A sessão não pode ser em uma data passada", resultado.Errors[0].ErrorMessage);
        }

        [Test]
        public void deve_validar_sessao()
        {
            ValidadorSessao validador = new ValidadorSessao();

            Sessao sessao = new Sessao();

            sessao.Data = DateTime.Now.AddDays(5);
            sessao.HorarioInicio = new(1, 30, 0);
            sessao.ValorIngresso = 5;
            sessao.TipoAnimacao = TipoAnimacao._3D;
            sessao.TipoAudio = TipoAudio.Original;
            sessao.FilmeId = Guid.NewGuid();
            sessao.SalaId = Guid.NewGuid();

            var resultado = validador.Validate(sessao);

            Assert.IsTrue(resultado.IsValid);
        }
    }
}
