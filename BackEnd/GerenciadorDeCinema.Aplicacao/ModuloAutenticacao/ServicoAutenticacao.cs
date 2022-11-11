using FluentResults;
using GerenciadorDeCinema.Aplicacao.Compartilhado;
using GerenciadorDeCinema.Dominio.ModuloAutenticacao;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Aplicacao.ModuloAutenticacao
{
    public class ServicoAutenticacao : ServicoBase<Usuario, ValidadorUsuario>
    {
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;

        public ServicoAutenticacao(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<Result<Usuario>> RegistrarUsuario(Usuario usuario, string senha)
        {
            var resultado = Validar(usuario);

            if (resultado.IsFailed)
            {
                return Result.Fail(resultado.Errors);
            }

            IdentityResult usuarioResult = await userManager.CreateAsync(usuario, senha);

            if (usuarioResult.Succeeded == false)
            {
                var erros = usuarioResult.Errors
                    .Select(identityError => new Error(identityError.Description));

                return Result.Fail(erros);
            }

            return Result.Ok(usuario);
        }

        public async Task<Result<Usuario>> AutenticarUsuario(string email, string senha)
        {
            SignInResult loginResult = await signInManager.PasswordSignInAsync(email, senha, false, true);

            if (loginResult.Succeeded == false && loginResult.IsLockedOut)
            {
                string msgErro = "Usuário Bloqueado";
                return Result.Fail(msgErro);
            }

            if (loginResult.Succeeded == false)
            {
                string msgErro = "Usuário ou senha incorretos";
                return Result.Fail(msgErro);
            }

            Usuario usuario = await userManager.FindByEmailAsync(email);

            return Result.Ok(usuario);
        }

        public async Task<Result<Usuario>> Sair()
        {
            await signInManager.SignOutAsync();

            return Result.Ok();
        }
    }
}
