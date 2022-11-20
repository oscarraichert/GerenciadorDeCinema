using FluentResults;
using GerenciadorDeCinema.Aplicacao.Compartilhado;
using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Dominio.ModuloFilme;
using GerenciadorDeCinema.Dominio.ModuloSessao;
using GerenciadorDeCinema.Infra.Orm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Aplicacao.ModuloFilme
{
    public class ServicoFilme: ServicoBase<Filme, ValidadorFilme>
    {
        private IRepositorioFilme repositorioFilme;
        private IRepositorioSessao repositorioSessao;
        private GerenciadorDeCinemaDbContext dbContext;


        public ServicoFilme(IRepositorioFilme repositorioFilme, IRepositorioSessao repositorioSessao, GerenciadorDeCinemaDbContext dbContext)
        {
            this.repositorioSessao = repositorioSessao;
            this.repositorioFilme = repositorioFilme;
            this.dbContext = dbContext;
        }

        public Result<Filme> Inserir(Filme novoFilme)
        {
            Result resultado = Validar(novoFilme);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            if (repositorioFilme.VerificarTituloRepetido(novoFilme))
            {
                return Result.Fail(new Error("Já existe um filme com esse título"));
            }          

            repositorioFilme.Inserir(novoFilme);

            dbContext.SaveChanges();

            return Result.Ok(novoFilme);
        }

        public Result<Filme> Editar(Filme filme)
        {
            Result resultado = Validar(filme);
            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            repositorioFilme.Editar(filme);

            dbContext.SaveChanges();

            return Result.Ok(filme);
        }

        public Result Excluir(Guid id)
        {
            var filmeResult = SelecionarPorId(id);

            if (filmeResult.IsSuccess)
                return Excluir(filmeResult.Value);

            return Result.Fail(filmeResult.Errors);
        }

        private Result Excluir(Filme filme)
        {
            var sessoes = repositorioSessao.SelecionarTodos();

            if (sessoes.Any(sessao => sessao.FilmeId == filme.Id))
            {
                return Result.Fail(new Error("O filme está vinculado a uma sessão"));
            }

            repositorioFilme.Excluir(filme);

            dbContext.SaveChanges();

            return Result.Ok();
        }

        public Result<Filme> SelecionarPorId(Guid id)
        {
            var filme = repositorioFilme.SelecionarPorId(id);

            if (filme == null)
            {
                return Result.Fail($"Filme {id} não encontrado");
            }

            return Result.Ok(filme);
        }

        public Result<List<Filme>> SelecionarTodos()
        {
            var filmes = repositorioFilme.SelecionarTodos();

            if (filmes == null)
            {
                return Result.Fail($"Falha ao tentar selecionar filmes");
            }

            return Result.Ok(filmes);
        }
    }
}
