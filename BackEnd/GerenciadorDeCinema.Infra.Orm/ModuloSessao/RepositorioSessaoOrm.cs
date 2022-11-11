using GerenciadorDeCinema.Dominio.ModuloSessao;
using GerenciadorDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Infra.Orm.ModuloSessao
{
    public class RepositorioSessaoOrm: IRepositorioSessao
    {
        private DbSet<Sessao> sessoes;
        public GerenciadorDeCinemaDbContext dbContext;

        public RepositorioSessaoOrm(GerenciadorDeCinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
            sessoes = dbContext.Set<Sessao>();
        }

        public void Inserir(Sessao novoRegistro)
        {
            sessoes.Add(novoRegistro);
        }

        public void Editar(Sessao registro)
        {
            sessoes.Update(registro);
        }

        public void Excluir(Sessao registro)
        {
            sessoes.Remove(registro);
        }

        public Sessao SelecionarPorId(Guid id)
        {
            return sessoes.SingleOrDefault(x => x.Id == id);
        }

        public List<Sessao> SelecionarTodos()
        {
            return sessoes.ToList();
        }
    }
}
