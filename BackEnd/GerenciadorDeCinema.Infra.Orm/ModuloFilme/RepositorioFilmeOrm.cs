using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.Dominio.ModuloFilme;
using GerenciadorDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Infra.Orm.ModuloFilme
{
    public class RepositorioFilmeOrm : IRepositorioFilme
    {
        private DbSet<Filme> filmes;
        public GerenciadorDeCinemaDbContext dbContext;

        public RepositorioFilmeOrm(GerenciadorDeCinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
            filmes = dbContext.Set<Filme>();
        }

        public void Editar(Filme registro)
        {
            filmes.Update(registro);
        }

        public void Excluir(Filme registro)
        {
            filmes.Remove(registro);
        }

        public void Inserir(Filme novoRegistro)
        {
            filmes.Add(novoRegistro);
        }

        public Filme SelecionarPorId(Guid id)
        {
            return filmes.SingleOrDefault(x => x.Id == id);
        }

        public List<Filme> SelecionarTodos()
        {
            return filmes.ToList();
        }

        public bool VerificarTituloRepetido(Filme novoFilme)
        {
            return filmes.Any(x => x.Titulo == novoFilme.Titulo);
        }
    }
}
