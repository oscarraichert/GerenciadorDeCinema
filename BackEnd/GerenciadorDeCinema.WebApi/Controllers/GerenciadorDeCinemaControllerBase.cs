using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeCinema.WebApi.Controllers
{
    [ApiController]
    public abstract class GerenciadorDeCinemaControllerBase : ControllerBase
    {
        protected ActionResult InternalError<T>(Result<T> registroResult)
        {
            return StatusCode(500, new
            {
                sucesso = false,
                erros = registroResult.Errors.Select(x => x.Message)
            });
        }

        protected ActionResult BadRequest<T>(Result<T> registroResult)
        {
            return StatusCode(300, new
            {
                sucesso = false,
                erros = registroResult.Errors.Select(x => x.Message)
            });
        }

        protected ActionResult NotFound<T>(Result<T> registroResult)
        {
            return StatusCode(404, new
            {
                sucesso = false,
                erros = registroResult.Errors.Select(x => x.Message)
            });
        }

        protected static bool RegistroNaoEncontrado<T>(Result<T> registroResult)
        {
            return registroResult.Errors.Any(x => x.Message.Contains("não encontrad"));
        }
    }
}
