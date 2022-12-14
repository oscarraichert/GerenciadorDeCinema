using GerenciadorDeCinema.Dominio.Filmes;

namespace GerenciadorDeCinema.Aplicacao.ViewModels.ModuloSessao
{
    public class ListarSessaoViewModel
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public string HorarioInicio { get; set; }

        public string FilmeId { get; set; }

        public string TituloFilme { get; set; }
    }
}
