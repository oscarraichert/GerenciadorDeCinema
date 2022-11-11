using AutoMapper;
using GerenciadorDeCinema.Aplicacao.ModuloFilme;
using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.WebApi.ViewModels.ModuloFilme;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeCinema.WebApi.Controllers
{
    [Route("api/filmes")]
    [ApiController]
    public class FilmeController : GerenciadorDeCinemaControllerBase
    {
        private readonly ServicoFilme servicoFilme;
        private readonly IMapper mapeadorFilmes;

        public FilmeController(ServicoFilme servicoFilme, IMapper mapeadorFilmes)
        {
            this.servicoFilme = servicoFilme;
            this.mapeadorFilmes = mapeadorFilmes;
        }

        [HttpPost]
        public ActionResult<FormsFilmeViewModel> Inserir(InserirFilmeViewModel filmeVM)
        {
            var filme = mapeadorFilmes.Map<Filme>(filmeVM);

            var filmeResult = servicoFilme.Inserir(filme);

            if (filmeResult.IsFailed)
            {
                return InternalError(filmeResult);
            }

            return Ok(new
            {
                sucesso = true,
                dados = filmeVM
            });
        }

        [HttpPut("{id:guid}")]
        public ActionResult<FormsFilmeViewModel> Editar(Guid id, EditarFilmeViewModel filmeVM)
        {
            var filmeResult = servicoFilme.SelecionarPorId(id);

            if (filmeResult.IsFailed && RegistroNaoEncontrado(filmeResult))
            {
                return NotFound(filmeResult);
            }

            var filme = mapeadorFilmes.Map(filmeVM, filmeResult.Value);

            filmeResult = servicoFilme.Editar(filme);

            if (filmeResult.IsFailed)
            {
                return InternalError(filmeResult);
            }

            return Ok(new
            {
                sucesso = true,
                dados = filmeVM
            });
        }

        [HttpDelete("{id:guid}")]
        public ActionResult Excluir(Guid id)
        {
            var result = servicoFilme.Excluir(id);

            if (result.IsFailed && RegistroNaoEncontrado<Filme>(result))
            {
                return NotFound<Filme>(result);
            }

            if (result.IsFailed)
            {
                return InternalError<Filme>(result);
            }

            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<ListarFilmeViewModel>> SelecionarTodos()
        {
            var filmeResult = servicoFilme.SelecionarTodos();

            if (filmeResult.IsFailed)
            {
                return InternalError(filmeResult);
            }

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorFilmes.Map<List<ListarFilmeViewModel>>(filmeResult.Value)
            });
        }

        [HttpGet("{id:guid}")]
        public ActionResult<VisualizarFilmeViewModel> SelecionarFilmePorId(Guid id)
        {
            var filmeResult = servicoFilme.SelecionarPorId(id);

            if (filmeResult.IsFailed && RegistroNaoEncontrado(filmeResult))
            {
                return NotFound(filmeResult);
            }

            if (filmeResult.IsFailed)
            {
                return InternalError(filmeResult);
            }

            return Ok(new
            {
                sucesso = true,
                dados = mapeadorFilmes.Map<FormsFilmeViewModel>(filmeResult.Value)
            });
        }
    }
}
