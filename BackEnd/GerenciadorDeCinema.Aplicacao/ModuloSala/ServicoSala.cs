using AutoMapper;
using FluentResults;
using GerenciadorDeCinema.Aplicacao.Compartilhado;
using GerenciadorDeCinema.Aplicacao.ViewModels.ModuloSala;
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
        private readonly IMapper mapeadorSalas;

        public ServicoSala(IRepositorioSala repositorioSala, IMapper mapeadorSalas)
        {
            this.repositorioSala = repositorioSala;
            this.mapeadorSalas = mapeadorSalas;
        }

        public Result<List<ListarSalaViewModel>> SelecionarTodas()
        {
            var salas = repositorioSala.SelecionarTodos();

            var salasVM = mapeadorSalas.Map<List<ListarSalaViewModel>>(salas);

            if (salas == null)
            {
                return Result.Fail("Falha ao selecionar as salas");
            }

            return Result.Ok(salasVM);
        }
    }
}
