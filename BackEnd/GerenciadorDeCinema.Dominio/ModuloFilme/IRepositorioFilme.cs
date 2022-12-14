using GerenciadorDeCinema.Dominio.Compartilhado;
using GerenciadorDeCinema.Dominio.Filmes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Dominio.ModuloFilme
{
    public interface IRepositorioFilme: IRepositorio<Filme>
    {
        public bool VerificarTituloRepetido(Filme filme);

        void Excluir(Guid id);
    }
}
