using AutoMapper;
using GerenciadorDeCinema.Aplicacao.ModuloSala;
using GerenciadorDeCinema.Aplicacao.ViewModels.ModuloSala;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeCinema.WebApi.Controllers
{
    [Route("api/salas")]
    [ApiController]
    [Authorize]
    public class SalaController : GerenciadorDeCinemaControllerBase
    {
        private readonly ServicoSala servicoSala;

        public SalaController(ServicoSala servicoSala, IMapper mapeadorSalas)
        {
            this.servicoSala = servicoSala;
        }

        [HttpGet]
        public ActionResult<List<ListarSalaViewModel>> SelecionarTodos()
        {
            var salaResult = servicoSala.SelecionarTodas();

            if (salaResult.IsFailed)
            {
                return InternalError(salaResult);
            }

            return Ok(new
            {
                sucesso = true,
                dados = salaResult.Value
            });
        }
    }
}
