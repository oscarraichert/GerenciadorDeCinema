using Microsoft.Extensions.Configuration;
using System.IO;

namespace GerenciadorDeCinema.Infra.Config
{
    public class GerenciadorDeCinemaAppConfig
    {
        public GerenciadorDeCinemaAppConfig(IConfiguration configuracao)
        {
            var connectionString = configuracao.GetConnectionString("SqlServer");

            ConnectionStrings = new ConnectionStrings { SqlServer = connectionString }; 
        }
    }
}