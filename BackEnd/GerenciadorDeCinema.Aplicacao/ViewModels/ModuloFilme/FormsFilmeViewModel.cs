using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeCinema.Aplicacao.ViewModels.ModuloFilme
{
    public class FormsFilmeViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public string Duracao { get; set; }
    }

    public class InserirFilmeViewModel : FormsFilmeViewModel
    {
        public InserirFilmeViewModel()
        {
            Id = Guid.NewGuid();
        }
    }

    public class EditarFilmeViewModel : FormsFilmeViewModel { }

    public class VisualizarFilmeViewModel : FormsFilmeViewModel { }
}
