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

        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string SqlServer { get; set; }
    }
}