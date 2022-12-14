using GerenciadorDeCinema.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Dominio.ModuloSessao
{
    public interface IRepositorioSessao: IRepositorio<Sessao>
    {
        void Excluir(Guid id);
    }
}
