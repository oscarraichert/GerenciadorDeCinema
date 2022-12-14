﻿using AutoMapper;
using GerenciadorDeCinema.Dominio.ModuloAutenticacao;
using GerenciadorDeCinema.Aplicacao.ViewModels.ModuloAutenticacao;

namespace GerenciadorDeCinema.WebApi.Config.AutoMapperConfig
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<RegistrarUsuarioViewModel, Usuario>()
                .ForMember(destino => destino.EmailConfirmed, opt => opt.MapFrom(origem => true))
                .ForMember(destino => destino.UserName, opt => opt.MapFrom(origem => origem.Email));
        }
    }
}
