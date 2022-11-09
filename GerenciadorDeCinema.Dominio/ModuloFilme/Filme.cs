using GerenciadorDeCinema.Dominio.Compartilhado;

namespace GerenciadorDeCinema.Dominio.Filmes
{
    public class Filme: EntidadeBase
    {    
        public string Imagem { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public TimeSpan Duracao { get; set; }

        public Filme(string imagem, string titulo, string descricao, TimeSpan duracao)
        {
            Imagem = imagem;
            Titulo = titulo;
            Descricao = descricao;
            Duracao = duracao;
        }
    }
}