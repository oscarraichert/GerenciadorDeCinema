namespace GerenciadorDeCinema.Aplicacao.ViewModels.ModuloAutenticacao
{
    public class TokenViewModel
    {
        public string Chave { get; set; }

        public UsuarioTokenViewModel UsuarioToken { get; set; }

        public DateTime DataExpiracao { get; set; }
    }
}
