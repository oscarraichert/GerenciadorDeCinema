using GerenciadorDeCinema.Dominio.Compartilhado;
using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Dominio.ModuloSala;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Dominio.ModuloSessao
{
    public class Sessao: EntidadeBase
    {
        public DateTime Data { get; set; }

        public DateTime HorarioInicio { get; set; }

        public DateTime HorarioFim { get ; set; }

        public decimal ValorIngresso { get; set; }

        public TipoAnimacao TipoAnimacao { get ; set; }

        public TipoAudio TipoAudio { get; set; }

        public Filme Filme { get; set; }

        public string FilmeId { get; set; }

        public Sala Sala { get; set; }

        public string SalaId { get; set; }

        public Sessao(DateTime data, DateTime horarioInicio, DateTime horarioFim, decimal valorIngresso, TipoAnimacao tipoAnimacao, TipoAudio tipoAudio, Filme filme, Sala sala)
        {
            Data = data;
            HorarioInicio = horarioInicio;
            ValorIngresso = valorIngresso;
            TipoAnimacao = tipoAnimacao;
            TipoAudio = tipoAudio;
            Filme = filme;
            Sala = sala;
            HorarioFim = HorarioInicio + Filme.Duracao;
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
