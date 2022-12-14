using GerenciadorDeCinema.Aplicacao.ModuloFilme;
using GerenciadorDeCinema.Aplicacao.ViewModels.ModuloAutenticacao;
using GerenciadorDeCinema.Aplicacao.ViewModels.ModuloFilme;
using GerenciadorDeCinema.Dominio.ModuloAutenticacao;
using GerenciadorDeCinema.WebApi.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Integração.Tests
{
    public class FilmeTesteIntegracao : IClassFixture<CustomWebApplicationFactory<FilmeController>>
    {
        private readonly CustomWebApplicationFactory<FilmeController> factory;

        public FilmeTesteIntegracao(CustomWebApplicationFactory<FilmeController> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task deve_retornar_sucesso_ao_inserir_filme()
        {
            var client = factory.CreateClient();

            using var scope = factory.Server.Services.GetService<IServiceScopeFactory>().CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();
            var servicoFilme = scope.ServiceProvider.GetService<ServicoFilme>();

            InserirFilmeViewModel filme = new();

            filme.Imagem = "imagem teste inserir";
            filme.Titulo = "titulo teste inserir";
            filme.Descricao = "descricao teste inserir";
            filme.Duracao = new TimeSpan(1, 45, 55).ToString();

            client.DefaultRequestHeaders.Authorization = await ObterTokenAutenticacao(client);

            var response = await client.PostAsync("/api/filmes", new StringContent(JsonConvert.SerializeObject(filme), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            servicoFilme.Excluir(filme.Id);

            await userManager.DeleteAsync(new Usuario()
            {
                Email = "usuarioTeste@gmail.com"
            });

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task deve_retornar_sucesso_ao_excluir_filme()
        {
            var client = factory.CreateClient();

            using var scope = factory.Server.Services.GetService<IServiceScopeFactory>().CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();
            var servicoFilme = scope.ServiceProvider.GetService<ServicoFilme>();

            InserirFilmeViewModel filme = new();

            filme.Imagem = "imagem teste excluir filme";
            filme.Titulo = "titulo teste excluir filme";
            filme.Descricao = "descricao teste excluir filme";
            filme.Duracao = new TimeSpan(2, 00, 00).ToString();

            client.DefaultRequestHeaders.Authorization = await ObterTokenAutenticacao(client);

            await client.PostAsync("/api/filmes", new StringContent(JsonConvert.SerializeObject(filme), Encoding.UTF8, "application/json"));

            var response = await client.DeleteAsync("/api/filmes/" + filme.Id);

            response.EnsureSuccessStatusCode();

            await userManager.DeleteAsync(new Usuario()
            {
                Email = "usuarioTeste@gmail.com"
            });

            Assert.Equal(204, (int)response.StatusCode);
        }

        [Fact]
        public async Task deve_retornar_sucesso_ao_selecionar_filmes()
        {
            var client = factory.CreateClient();

            using var scope = factory.Server.Services.GetService<IServiceScopeFactory>().CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();
            var servicoFilme = scope.ServiceProvider.GetService<ServicoFilme>();

            InserirFilmeViewModel filme = new();

            filme.Imagem = "imagem teste selecionar 1";
            filme.Titulo = "titulo teste selecionar 1";
            filme.Descricao = "descricao teste selecionar 1";
            filme.Duracao = new TimeSpan(3, 11, 00).ToString();

            InserirFilmeViewModel filme2 = new();

            filme2.Imagem = "imagem teste selecionar 2";
            filme2.Titulo = "titulo teste selecionar 2";
            filme2.Descricao = "descricao teste selecionar 2";
            filme2.Duracao = new TimeSpan(1, 22, 15).ToString();

            client.DefaultRequestHeaders.Authorization = await ObterTokenAutenticacao(client);

            await client.PostAsync("/api/filmes", new StringContent(JsonConvert.SerializeObject(filme), Encoding.UTF8, "application/json"));

            await client.PostAsync("/api/filmes", new StringContent(JsonConvert.SerializeObject(filme2), Encoding.UTF8, "application/json"));

            var response = await client.GetAsync("/api/filmes");

            await client.DeleteAsync("/api/filmes/" + filme.Id);

            await client.DeleteAsync("/api/filmes/" + filme2.Id);

            response.EnsureSuccessStatusCode();

            await userManager.DeleteAsync(new Usuario()
            {
                Email = "usuarioTeste@gmail.com"
            });

            Assert.Equal(200, (int)response.StatusCode);
        }

        private static async Task<AuthenticationHeaderValue> ObterTokenAutenticacao(HttpClient client)
        {
            var registroResponse = await client.PostAsync("/api/conta/registrar", new StringContent(JsonConvert.SerializeObject(
                            new RegistrarUsuarioViewModel(
                                    "usuario teste",
                                    "usuarioTeste@gmail.com",
                                    "#Usuario123",
                                    "#Usuario123"
                                )
                            ),
                            Encoding.UTF8,
                            "application/json"
                            ));

            var response = await client.PostAsync("/api/conta/autenticar", new StringContent(JsonConvert.SerializeObject(
                new AutenticarUsuarioViewModel("usuarioTeste@gmail.com", "#Usuario123")),
                Encoding.UTF8,
                "application/json"
                ));

            var responseContent = await response.Content.ReadAsStringAsync();

            var jObject = Newtonsoft.Json.Linq.JObject.Parse(responseContent);

            return new AuthenticationHeaderValue("Bearer", jObject["dados"]["chave"].ToString());
        }
    }
}
