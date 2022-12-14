using GerenciadorDeCinema.Aplicacao.ModuloFilme;
using GerenciadorDeCinema.Aplicacao.ModuloSala;
using GerenciadorDeCinema.Aplicacao.ModuloSessao;
using GerenciadorDeCinema.Aplicacao.ViewModels.ModuloAutenticacao;
using GerenciadorDeCinema.Aplicacao.ViewModels.ModuloFilme;
using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Dominio.ModuloAutenticacao;
using GerenciadorDeCinema.Dominio.ModuloSessao;
using GerenciadorDeCinema.WebApi.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace GerenciadorDeCinema.Integração.Tests
{
    public class SessaoTesteIntegracao : IClassFixture<CustomWebApplicationFactory<FilmeController>>
    {
        private readonly CustomWebApplicationFactory<FilmeController> factory;

        public SessaoTesteIntegracao(CustomWebApplicationFactory<FilmeController> factory)
        {
            this.factory = factory;
        }        

        [Fact]
        public async Task deve_retornar_sucesso_ao_inserir_sessao()
        {
            var client = factory.CreateClient();

            using var scope = factory.Server.Services.GetService<IServiceScopeFactory>().CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();
            var servicoFilme = scope.ServiceProvider.GetService<ServicoFilme>();
            var servicoSala = scope.ServiceProvider.GetService<ServicoSala>();
            var servicoSessao = scope.ServiceProvider.GetService<ServicoSessao>();

            var salas = servicoSala.SelecionarTodas().Value;

            InserirFilmeViewModel filme = new();

            filme.Imagem = "imagem teste";
            filme.Titulo = "titulo teste";
            filme.Descricao = "descricao teste";
            filme.Duracao = new TimeSpan(1, 30, 25).ToString();                

            servicoFilme.Inserir(filme);

            Sessao sessao = new(
                DateTime.Now.AddDays(11),
                new(15, 35, 0),
                5,
                TipoAnimacao._3D,
                TipoAudio.Original,
                filme.Id,
                salas[0].Id
                );

            client.DefaultRequestHeaders.Authorization = await ObterTokenAutenticacao(client);

            var response = await client.PostAsync("/api/sessoes", new StringContent(JsonConvert.SerializeObject(sessao), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();            

            servicoSessao.Excluir(sessao.Id);

            servicoFilme.Excluir(filme.Id);

            await userManager.DeleteAsync(new Usuario()
            {
                Email = "usuarioTeste@gmail.com"
            });

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task deve_retornar_sucesso_ao_excluir_sessao()
        {
            var client = factory.CreateClient();

            using var scope = factory.Server.Services.GetService<IServiceScopeFactory>().CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();
            var servicoFilme = scope.ServiceProvider.GetService<ServicoFilme>();
            var servicoSala = scope.ServiceProvider.GetService<ServicoSala>();
            var servicoSessao = scope.ServiceProvider.GetService<ServicoSessao>();

            var salas = servicoSala.SelecionarTodas().Value;

            InserirFilmeViewModel filme = new();

            filme.Imagem = "imagem teste excluir";
            filme.Titulo = "titulo teste excluir";
            filme.Descricao = "descricao teste excluir";
            filme.Duracao = new TimeSpan(3, 15, 00).ToString();

            servicoFilme.Inserir(filme);

            Sessao sessao = new(
                DateTime.Now.AddDays(17),
                new(18, 35, 0),
                5,
                TipoAnimacao._2D,
                TipoAudio.Dublado,
                filme.Id,
                salas[1].Id
                );

            client.DefaultRequestHeaders.Authorization = await ObterTokenAutenticacao(client);

            await client.PostAsync("/api/sessoes", new StringContent(JsonConvert.SerializeObject(sessao), Encoding.UTF8, "application/json"));

            var response = await client.DeleteAsync("/api/sessoes/" + sessao.Id);

            response.EnsureSuccessStatusCode();

            servicoFilme.Excluir(filme.Id);

            await userManager.DeleteAsync(new Usuario()
            {
                Email = "usuarioTeste@gmail.com"
            });

            Assert.Equal(204, (int)response.StatusCode);
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