using GerenciadorDeCinema.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Dominio.ModuloSala
{
    public interface IRepositorioSala : IRepositorio<Sala>
    {
        void InserirSalas(List<Sala> salas);
    }
}
