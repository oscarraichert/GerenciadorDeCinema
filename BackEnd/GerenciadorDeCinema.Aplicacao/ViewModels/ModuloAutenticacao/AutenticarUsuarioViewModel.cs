using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeCinema.Aplicacao.ViewModels.ModuloAutenticacao
{
    public class AutenticarUsuarioViewModel
    {
        public AutenticarUsuarioViewModel(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O formato do campo {0} está inválido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }
    }
}
