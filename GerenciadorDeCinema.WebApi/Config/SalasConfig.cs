using GerenciadorDeCinema.Dominio.ModuloSala;

namespace GerenciadorDeCinema.WebApi.Config
{
    public static class SalasConfig
    {
        public static void ConfigurarSalas(this WebApplication webApplication)
        {
            var repositorioSala = webApplication.Services.GetService<IRepositorioSala>();

            var salas = webApplication.Configuration.GetValue<List<Sala>>("ConfiguracaoSalas");

            repositorioSala.InserirSalas(salas);
        }
    }
}
