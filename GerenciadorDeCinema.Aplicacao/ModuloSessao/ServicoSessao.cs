using FluentResults;
using GerenciadorDeCinema.Aplicacao.Compartilhado;
using GerenciadorDeCinema.Dominio.ModuloSessao;
using GerenciadorDeCinema.Infra.Orm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Aplicacao.ModuloSessao
{
    public class ServicoSessao: ServicoBase<Sessao, ValidadorSessao>
    {
        private IRepositorioSessao repositorioSessao;
        private GerenciadorDeCinemaDbContext dbContext;

        public ServicoSessao(IRepositorioSessao repositorioSessao, GerenciadorDeCinemaDbContext dbContext)
        {
            this.repositorioSessao = repositorioSessao;
            this.dbContext = dbContext;
        }

        public Result<Sessao> Inserir(Sessao novaSessao)
        {
            Result resultado = Validar(novaSessao);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            repositorioSessao.Inserir(novaSessao);

            dbContext.SaveChanges();

            return Result.Ok(novaSessao);
        }

        public Result<Sessao> Editar(Sessao sessao)
        {
            Result resultado = Validar(sessao);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            repositorioSessao.Editar(sessao);

            dbContext.SaveChanges();

            return Result.Ok(sessao);
        }

        public Result Excluir(Guid id)
        {
            var sessaoResult = SelecionarPorId(id);

            if (sessaoResult.IsSuccess)
            {
                return Excluir(sessaoResult.Value);
            }

            return Result.Fail(sessaoResult.Errors);
        }

        private Result Excluir(Sessao sessao)
        {
            repositorioSessao.Excluir(sessao);

            dbContext.SaveChanges();

            return Result.Ok();
        }

        public Result<Sessao> SelecionarPorId(Guid id)
        {
            var sessao = repositorioSessao.SelecionarPorId(id);

            if (sessao == null)
            {
                return Result.Fail($"Sessao {id} não encontrada");
            }

            return Result.Ok(sessao);
        }

        public Result<List<Sessao>> SelecionarTodas()
        {
            var sessoes = repositorioSessao.SelecionarTodos();

            if (sessoes == null)
            {
                return Result.Fail("Falha ao tentar selecionar as sessões");
            }

            return Result.Ok(sessoes);
        }
    }
}
