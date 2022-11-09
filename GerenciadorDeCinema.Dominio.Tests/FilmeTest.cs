using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Infra.Orm.ModuloFilme;

namespace GerenciadorDeCinema.Dominio.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Não_deve_adicionar_dois_filmes_com_o_mesmo_titulo()
        {
            //var repositorioFilme = new RepositorioFilmeOrm();

            //repositorioFilme.Inserir(new Filme("4thyuhpwehf-9ry-9ewh", "Batman", "Ele é a vingança", new TimeSpan(2, 31, 0)));
        }
    }
}