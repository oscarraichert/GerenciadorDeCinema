using AutoMapper;
using GerenciadorDeCinema.Aplicacao.ModuloSessao;
using GerenciadorDeCinema.Dominio.ModuloSessao;
using GerenciadorDeCinema.WebApi.ViewModels.ModuloSessao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeCinema.WebApi.Controllers
{
    [Route("api/sessoes")]
    [ApiController]
    public class SessaoController : GerenciadorDeCinemaControllerBase
    {
        private readonly ServicoSessao servicoSessao;
        private readonly IMapper mapeadorSessoes;

        public SessaoController(ServicoSessao servicoSessao, IMapper mapeadorSessoes)
        {
            this.servicoSessao = servicoSessao;
            this.mapeadorSessoes = mapeadorSessoes;
        }

        [HttpPost]
        public ActionResult<FormsSessaoViewModel> Inserir(InserirSessaoViewModel sessaoVM)
        {
            var sessao = mapeadorSessoes.Map<Sessao>(sessaoVM);

            var sessaoResult = servicoSessao.Inserir(sessao);

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
            var sessaoResult = servicoSessao.SelecionarPorId(id);

            if (sessaoResult.IsFailed && RegistroNaoEncontrado(sessaoResult))
            {
                return NotFound(sessaoResult);
            }

            var sessao = mapeadorSessoes.Map(sessaoVM, sessaoResult.Value);

            sessaoResult = servicoSessao.Editar(sessao);

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
                dados = mapeadorSessoes.Map<List<ListarSessaoViewModel>>(sessaoResult.Value)
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
                dados = mapeadorSessoes.Map<VisualizarSessaoCompletaViewModel>(sessaoResult.Value)
            });
        }
    }
}
