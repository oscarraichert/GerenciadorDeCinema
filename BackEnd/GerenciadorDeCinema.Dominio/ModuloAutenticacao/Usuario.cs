using GerenciadorDeCinema.Dominio.Compartilhado;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Dominio.ModuloAutenticacao
{
    public class Usuario : IdentityUser<Guid>
    {
        public string Nome { get; set; }
    }
}
