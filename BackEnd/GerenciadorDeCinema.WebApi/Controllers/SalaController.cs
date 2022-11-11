using AutoMapper;
using GerenciadorDeCinema.Aplicacao.ModuloSala;
using GerenciadorDeCinema.WebApi.ViewModels.ModuloSala;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeCinema.WebApi.Controllers
{
    [Route("api/salas")]
    [ApiController]
    public class SalaController : GerenciadorDeCinemaControllerBase
    {
        private readonly ServicoSala servicoSala;
        private readonly IMapper mapeadorSalas;

        public SalaController(ServicoSala servicoSala, IMapper mapeadorSalas)
        {
            this.servicoSala = servicoSala;
            this.mapeadorSalas = mapeadorSalas;
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
                dados = mapeadorSalas.Map<List<ListarSalaViewModel>>(salaResult.Value)
            });
        }
    }
}
