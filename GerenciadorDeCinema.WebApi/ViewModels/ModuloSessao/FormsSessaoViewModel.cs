using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Dominio.ModuloSala;
using GerenciadorDeCinema.Dominio.ModuloSessao;

namespace GerenciadorDeCinema.WebApi.ViewModels.ModuloSessao
{
    public class FormsSessaoViewModel
    {
        Guid Id { get; set; }

        public DateTime Data { get; set; }

        public string HorarioInicio { get; set; }

        public decimal ValorIngresso { get; set; }

        public TipoAnimacao TipoAnimacao { get; set; }

        public TipoAudio TipoAudio { get; set; }

        public string FilmeId { get; set; }

        public string SalaId { get; set; }
    }

    public class InserirSessaoViewModel: FormsSessaoViewModel { }

    public class EditarSessaoViewModel : FormsSessaoViewModel { }

    public class VisualizarSessaoViewModel : FormsSessaoViewModel { }

    public class VisualizarSessaoCompletaViewModel : FormsSessaoViewModel
    {
        public string HorarioFim { get; set; }
    }
}
