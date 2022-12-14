using AutoMapper;
using GerenciadorDeCinema.Aplicacao.ModuloSessao;
using GerenciadorDeCinema.Dominio.ModuloSessao;
using GerenciadorDeCinema.Aplicacao.ViewModels.ModuloSessao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeCinema.WebApi.Controllers
{
    [Route("api/sessoes")]
    [ApiController]
    [Authorize]
    public class SessaoController : GerenciadorDeCinemaControllerBase
    {
        private readonly ServicoSessao servicoSessao;

        public SessaoController(ServicoSessao servicoSessao, IMapper mapeadorSessoes)
        {
            this.servicoSessao = servicoSessao;
        }

        [HttpPost]
        public ActionResult<Sessao> Inserir(InserirSessaoViewModel sessaoVM)
        {
            var sessaoResult = servicoSessao.Inserir(sessaoVM);

            if (sessaoResult.IsFailed)
            {
                return InternalError(sessaoResult);
            }

            return Ok(new
            {
                sucesso = true,
                dados = sessaoVM
            });
        }

        [HttpPut("{id:guid}")]
        public ActionResult<FormsSessaoViewModel> Editar(Guid id, EditarSessaoViewModel sessaoVM)
        {
            var sessaoEditada = servicoSessao.Editar(sessaoVM);

            if (sessaoEditada.IsFailed)
            {
                return InternalError(sessaoEditada);
            }

            return Ok(new
            {
                sucesso = true,
                dados = sessaoEditada.Value
            });
        }

        [HttpDelete("{id:guid}")]
        public ActionResult Excluir(Guid id)
        {
            var result = servicoSessao.Excluir(id);

            if (result.IsFailed && RegistroNaoEncontrado<Sessao>(result))
            {
                return NotFound<Sessao>(result);
            }

            if (result.IsFailed)
            {
                return InternalError<Sessao>(result);
            }

            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<ListarSessaoViewModel>> SelecionarTodos()
        {
            var sessaoResult = servicoSessao.SelecionarTodas();

            if (sessaoResult.IsFailed)
            {
                return InternalError(sessaoResult);
            }

            return Ok(new
            {
                sucesso = true,
                dados = sessaoResult.Value
            });
        }

        [HttpGet("{id:guid}")]
        public ActionResult<VisualizarSessaoCompletaViewModel> SelecionarSessaoPorId(Guid id)
        {
            var sessaoResult = servicoSessao.SelecionarPorId(id);

            if (sessaoResult.IsFailed && RegistroNaoEncontrado(sessaoResult))
            {
                return NotFound(sessaoResult);
            }

            if (sessaoResult.IsFailed)
            {
                return InternalError(sessaoResult);
            }

            return Ok(new
            {
                sucesso = true,
                dados = sessaoResult.Value
            });
        }
    }
}
