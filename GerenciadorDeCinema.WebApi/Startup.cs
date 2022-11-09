using GerenciadorDeCinema.WebApi.Config;

namespace GerenciadorDeCinema.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDependencyInjection();
        }
    }
}
