using GerenciadorDeCinema.Dominio.Compartilhado;
using GerenciadorDeCinema.Dominio.ModuloSessao;

namespace GerenciadorDeCinema.Dominio.ModuloSala
{
    public  class Sala: EntidadeBase
    {
        public string Nome { get; set; }

        public int QuantidadeAssentos { get; set; }

        public IEnumerable<Sessao> Sessoes { get; set; }

        public Sala(string nome, int quantidadeAssentos)
        {
            Nome = nome;
            QuantidadeAssentos = quantidadeAssentos;
        }

        public Sala()
        {

        }
    }
}
