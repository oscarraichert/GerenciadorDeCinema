using AutoMapper;
using FluentResults;
using GerenciadorDeCinema.Aplicacao.Compartilhado;
using GerenciadorDeCinema.Aplicacao.ViewModels.ModuloFilme;
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
        private readonly IMapper mapeadorFilmes;

        public ServicoFilme(IRepositorioFilme repositorioFilme, IRepositorioSessao repositorioSessao, GerenciadorDeCinemaDbContext dbContext, IMapper mapeadorFilmes)
        {
            this.repositorioSessao = repositorioSessao;
            this.repositorioFilme = repositorioFilme;
            this.dbContext = dbContext;
            this.mapeadorFilmes = mapeadorFilmes;
        }

        public Result<Filme> Inserir(InserirFilmeViewModel novoFilmeVM)
        {
            var novoFilme = mapeadorFilmes.Map<Filme>(novoFilmeVM);

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

        public Result<Filme> Editar(EditarFilmeViewModel filmeVM)
        {
            var filme = mapeadorFilmes.Map<Filme>(filmeVM);

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
            var filmeVM = SelecionarPorId(id);

            if (filmeVM.IsSuccess)
                return Excluir(filmeVM.Value);

            return Result.Fail(filmeVM.Errors);
        }

        private Result Excluir(VisualizarFilmeViewModel filme)
        {
            var sessoes = repositorioSessao.SelecionarTodos();

            if (sessoes.Any(sessao => sessao.FilmeId == filme.Id))
            {
                return Result.Fail(new Error("O filme está vinculado a uma sessão"));
            }

            repositorioFilme.Excluir(filme.Id);

            dbContext.SaveChanges();

            return Result.Ok();
        }

        public Result<VisualizarFilmeViewModel> SelecionarPorId(Guid id)
        {
            var filme = repositorioFilme.SelecionarPorId(id);            

            if (filme == null)
            {
                return Result.Fail($"Filme {id} não encontrado");
            }

            var filmeVM = mapeadorFilmes.Map<VisualizarFilmeViewModel>(filme);

            return Result.Ok(filmeVM);
        }

        public Result<List<ListarFilmeViewModel>> SelecionarTodos()
        {
            var filmes = repositorioFilme.SelecionarTodos();

            var filmesVM = mapeadorFilmes.Map<List<ListarFilmeViewModel>>(filmes);

            if (filmes == null)
            {
                return Result.Fail($"Falha ao tentar selecionar filmes");
            }

            return Result.Ok(filmesVM);
        }
    }
}
