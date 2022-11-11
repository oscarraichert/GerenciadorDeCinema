using GerenciadorDeCinema.Dominio.ModuloSala;
using GerenciadorDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Infra.Orm.ModuloSala
{
    public class RepositorioSalaOrm : IRepositorioSala
    {
        private DbSet<Sala> salas;
        public GerenciadorDeCinemaDbContext dbContext;

        public RepositorioSalaOrm(GerenciadorDeCinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
            salas = dbContext.Set<Sala>();
        }

        public void Editar(Sala registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Sala registro)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Sala novoRegistro)
        {
            salas.Add(novoRegistro);

            dbContext.SaveChanges();
        }

        public Sala SelecionarPorId(Guid numero)
        {
            throw new NotImplementedException();
        }

        public List<Sala> SelecionarTodos()
        {
            return salas.ToList();
        }

        public void InserirSalas(List<Sala> salas)
        {
            this.salas.AddRange(salas);

            dbContext.SaveChanges();
        }
    }
}
