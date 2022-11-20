using FluentResults;
using GerenciadorDeCinema.Aplicacao.Compartilhado;
using GerenciadorDeCinema.Dominio.ModuloFilme;
using GerenciadorDeCinema.Dominio.ModuloSessao;
using GerenciadorDeCinema.Infra.Orm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Aplicacao.ModuloSessao
{
    public class ServicoSessao : ServicoBase<Sessao, ValidadorSessao>
    {
        private readonly IRepositorioFilme repositorioFilme;
        private IRepositorioSessao repositorioSessao;
        private GerenciadorDeCinemaDbContext dbContext;

        public ServicoSessao(IRepositorioFilme repositorioFilme, IRepositorioSessao repositorioSessao, GerenciadorDeCinemaDbContext dbContext)
        {
            this.repositorioFilme = repositorioFilme;
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

            var sessaoOcupada = VerificarSessaoOcupada(novaSessao);

            if (sessaoOcupada)
            {
                return Result.Fail(new Error("O horário inserido não está disponível"));
            }

            novaSessao.HorarioFim = ObterHorarioFinal(novaSessao).TimeOfDay;

            repositorioSessao.Inserir(novaSessao);

            dbContext.SaveChanges();

            return Result.Ok(novaSessao);
        }

        public bool VerificarSessaoOcupada(Sessao sessao)
        {
            var finalSessao = ObterHorarioFinal(sessao);

            var inicioSessao = sessao.Data.Add(sessao.HorarioInicio);

            var sessaoOcupada = repositorioSessao.SelecionarTodos().Any(
                x => inicioSessao > x.Data.Add(x.HorarioInicio) &&
                inicioSessao < x.Data.Add(x.HorarioInicio.Add(repositorioFilme.SelecionarPorId(x.FilmeId).Duracao)) &&
                x.SalaId == sessao.SalaId
                );

            return sessaoOcupada;
        }

        public DateTime ObterHorarioFinal(Sessao sessao)
        {
            var filme = repositorioFilme.SelecionarPorId(sessao.FilmeId);

            var diaHoraFim = sessao.Data.Add(sessao.HorarioInicio.Add(filme.Duracao));

            return diaHoraFim;
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

            if (sessaoResult.Value.Data < DateTime.Now.AddDays(10))
            {
                return Result.Fail(new Error("A sessão só pode ser excluída se faltar mais de 10 dias para que ela ocorra."));
            }

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
