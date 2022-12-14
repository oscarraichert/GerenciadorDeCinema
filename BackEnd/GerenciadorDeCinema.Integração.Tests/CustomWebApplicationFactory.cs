using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using GerenciadorDeCinema.WebApi.Config;
using GerenciadorDeCinema.WebApi.Config.AutoMapperConfig;

namespace GerenciadorDeCinema.Integração.Tests
{
    public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.ConfigureDependencyInjection();
            serviceCollection.AddAutoMapper(typeof(AppProfileBase));
            //serviceCollection.ConfigurarSwagger();

            builder.ConfigureServices(services =>
            {                
                foreach (var service in serviceCollection)
                {
                    services.Add(service);
                }                
            }); 

            builder.UseEnvironment("Development");
        }
    }
}
