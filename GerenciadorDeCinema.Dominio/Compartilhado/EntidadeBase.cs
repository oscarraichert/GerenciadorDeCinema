using GerenciadorDeCinema.Dominio.ModuloAutenticacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Dominio.Compartilhado
{
    public class EntidadeBase
    {
        public Guid Id { get; set; }

        //public Guid UsuarioId { get; set; }

        //public Usuario Usuario { get; set; }

        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
