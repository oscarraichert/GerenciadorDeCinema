using AutoMapper;
using GerenciadorDeCinema.Aplicacao.ModuloFilme;
using GerenciadorDeCinema.Aplicacao.ModuloSala;
using GerenciadorDeCinema.Aplicacao.ModuloSessao;
using GerenciadorDeCinema.Dominio.ModuloFilme;
using GerenciadorDeCinema.Dominio.ModuloSala;
using GerenciadorDeCinema.Dominio.ModuloSessao;
using GerenciadorDeCinema.Infra.Config;
using GerenciadorDeCinema.Infra.Orm.Compartilhado;
using GerenciadorDeCinema.Infra.Orm.ModuloFilme;
using GerenciadorDeCinema.Infra.Orm.ModuloSala;
using GerenciadorDeCinema.Infra.Orm.ModuloSessao;

namespace GerenciadorDeCinema.WebApi.Config
{
    public static class DependencyInjectionConfig
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<GerenciadorDeCinemaDbContext>();

            services.AddSingleton<ConnectionStrings>();

            services.AddScoped<IRepositorioFilme, RepositorioFilmeOrm>();
            services.AddTransient<ServicoFilme>();

            services.AddScoped<IRepositorioSessao, RepositorioSessaoOrm>();
            services.AddTransient<ServicoSessao>();

            services.AddScoped<IRepositorioSala, RepositorioSalaOrm>();
            services.AddTransient<ServicoSala>();
        }
    }
}
