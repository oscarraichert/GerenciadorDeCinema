using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Dominio.ModuloSala;
using GerenciadorDeCinema.Dominio.ModuloSessao;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeCinema.Aplicacao.ViewModels.ModuloSessao
{
    public class FormsSessaoViewModel
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public string HorarioInicio { get; set; }

        public decimal ValorIngresso { get; set; }

        public TipoAnimacao TipoAnimacao { get; set; }

        public TipoAudio TipoAudio { get; set; }

        public string FilmeId { get; set; }

        public string SalaId { get; set; }
    }

    public class InserirSessaoViewModel : FormsSessaoViewModel
    {
    }

    public class EditarSessaoViewModel : FormsSessaoViewModel { }

    public class VisualizarSessaoViewModel : FormsSessaoViewModel { }

    public class VisualizarSessaoCompletaViewModel
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public string HorarioInicio { get; set; }

        public decimal ValorIngresso { get; set; }

        public string TipoAnimacao { get; set; }

        public string TipoAudio { get; set; }

        public string FilmeId { get; set; }

        public string SalaId { get; set; }

        public string TituloFilme { get; set; }

        public string NomeSala { get; set; }

        public string HorarioFim { get; set; }
    }
}
