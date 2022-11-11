using GerenciadorDeCinema.Aplicacao.ModuloAutenticacao;
using GerenciadorDeCinema.Dominio.ModuloAutenticacao;
using GerenciadorDeCinema.Infra.Orm.Compartilhado;
using Microsoft.AspNetCore.Identity;

namespace GerenciadorDeCinema.WebApi.Config
{
    public static class IdentityConfig
    {
        public static void ConfigurarAutenticacao(this IServiceCollection services)
        {
            services.AddIdentity<Usuario, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<GerenciadorDeCinemaDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<UserManager<Usuario>>();
            services.AddTransient<SignInManager<Usuario>>();
            services.AddTransient<ServicoAutenticacao>();
        }
    }
}
