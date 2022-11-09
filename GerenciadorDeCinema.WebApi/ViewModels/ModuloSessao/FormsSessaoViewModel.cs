using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Dominio.ModuloSala;
using GerenciadorDeCinema.Dominio.ModuloSessao;

namespace GerenciadorDeCinema.WebApi.ViewModels.ModuloSessao
{
    public class FormsSessaoViewModel
    {
        public DateTime Data { get; set; }

        public DateTime HorarioInicio { get; set; }

        public decimal ValorIngresso { get; set; }

        public TipoAnimacao TipoAnimacao { get; set; }

        public TipoAudio TipoAudio { get; set; }

        public string FilmeId { get; set; }

        public string SalaId { get; set; }
    }

    public class InserirSessaoViewModel: FormsSessaoViewModel { }
}
