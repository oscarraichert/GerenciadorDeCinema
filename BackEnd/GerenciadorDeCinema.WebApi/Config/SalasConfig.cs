using GerenciadorDeCinema.Dominio.ModuloSala;

namespace GerenciadorDeCinema.WebApi.Config
{
    public static class SalasConfig
    {
        public static void ConfigurarSalas(this WebApplication webApplication)
        {
            using var serviceScope = webApplication.Services.CreateScope();

            var repositorioSala = serviceScope.ServiceProvider.GetService<IRepositorioSala>();

            var salas = webApplication.Configuration.GetSection("ConfiguracaoSalas").Get<List<Sala>>();

            var salasRepo = repositorioSala.SelecionarTodos();

            foreach (Sala sala in salas)
            {
                if (salasRepo.Any(x => x.Nome == sala.Nome) == false)
                {
                    repositorioSala.Inserir(sala);
                }
            }            
        }
    }
}