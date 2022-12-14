using AutoMapper;
using GerenciadorDeCinema.Aplicacao.ModuloFilme;
using GerenciadorDeCinema.Aplicacao.ViewModels.ModuloFilme;
using GerenciadorDeCinema.Dominio.Filmes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeCinema.WebApi.Controllers
{
    [Route("api/filmes")]
    [ApiController]
    [Authorize]
    public class FilmeController : GerenciadorDeCinemaControllerBase
    {
        private readonly ServicoFilme servicoFilme;

        public FilmeController(ServicoFilme servicoFilme)
        {
            this.servicoFilme = servicoFilme;
        }

        [HttpPost]
        public ActionResult<Filme> Inserir(InserirFilmeViewModel filmeVM)
        {
            var filmeResult = servicoFilme.Inserir(filmeVM);

            if (filmeResult.IsFailed)
            {
                return InternalError(filmeResult);
            }

            return Ok(new
            {
                sucesso = true,
                dados = filmeResult.Value
            });
        }

        [HttpPut("{id:guid}")]
        public ActionResult<Filme> Editar(Guid id, EditarFilmeViewModel filmeVM)
        {
            var filmeResult = servicoFilme.Editar(filmeVM);

            if (filmeResult.IsFailed)
            {
                return InternalError(filmeResult);
            }

            return Ok(new
            {
                sucesso = true,
                dados = filmeResult.Value
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
                dados = filmeResult.Value
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
                dados = filmeResult.Value
            });
        }
    }
}
