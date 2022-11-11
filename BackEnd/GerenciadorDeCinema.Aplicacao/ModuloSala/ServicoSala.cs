using FluentResults;
using GerenciadorDeCinema.Aplicacao.Compartilhado;
using GerenciadorDeCinema.Dominio.ModuloSala;
using GerenciadorDeCinema.Infra.Orm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Aplicacao.ModuloSala
{
    public class ServicoSala : ServicoBase<Sala, ValidadorSala>
    {
        private IRepositorioSala repositorioSala;
        private GerenciadorDeCinemaDbContext dbContext;

        public ServicoSala(IRepositorioSala repositorioSala, GerenciadorDeCinemaDbContext dbContext)
        {
            this.repositorioSala = repositorioSala;
            this.dbContext = dbContext;
        }

        public Result<List<Sala>> SelecionarTodas()
        {
            var salas = repositorioSala.SelecionarTodos();

            if (salas == null)
            {
                return Result.Fail("Falha ao selecionar as salas");
            }

            return Result.Ok(salas);
        }
    }
}
