using GerenciadorDeCinema.Dominio.Compartilhado;
using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Dominio.ModuloSala;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Dominio.ModuloSessao
{
    public class Sessao: EntidadeBase
    {
        public DateTime Data { get; set; }

        public TimeSpan HorarioInicio { get; set; }

        public TimeSpan HorarioFim { get ; set; }

        public decimal ValorIngresso { get; set; }

        public TipoAnimacao TipoAnimacao { get ; set; }

        public TipoAudio TipoAudio { get; set; }

        [NotMapped]
        public string TituloFilme { get; set; }

        public Guid FilmeId { get; set; }

        [NotMapped]
        public Sala Sala { get; set; }

        public string SalaId { get; set; }

        public Sessao()
        {
                
        }
    }

    public enum TipoAnimacao
    {
        _2D,
        _3D
    }
    
    public enum TipoAudio
    {
        Original,
        Dublado
    }
}
