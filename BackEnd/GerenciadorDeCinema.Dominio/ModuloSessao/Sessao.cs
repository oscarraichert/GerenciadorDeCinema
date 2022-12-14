using GerenciadorDeCinema.Dominio.Compartilhado;
using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Dominio.ModuloSala;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public Guid FilmeId { get; set; }

        public Sala Sala { get; set; }

        public Filme Filme { get; set; }

        public Guid SalaId { get; set; }

        public Sessao()
        {

        }

        public Sessao(DateTime data, TimeSpan horarioInicio, decimal valorIngresso, TipoAnimacao tipoAnimacao, TipoAudio tipoAudio, Guid filmeId, Guid salaId)
        {
            Data = data;
            HorarioInicio = horarioInicio;
            ValorIngresso = valorIngresso;
            TipoAnimacao = tipoAnimacao;
            TipoAudio = tipoAudio;
            FilmeId = filmeId;
            SalaId = salaId;
        }
    }

    public enum TipoAnimacao
    {
        [Description("2D")]
        _2D,
        [Description("3D")]
        _3D
    }
    
    public enum TipoAudio
    {
        [Description("Original")]
        Original,
        [Description("Dublado")]
        Dublado
    }
}
