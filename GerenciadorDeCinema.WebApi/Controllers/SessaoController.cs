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
    }
}
