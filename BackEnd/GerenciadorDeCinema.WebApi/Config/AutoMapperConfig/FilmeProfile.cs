using AutoMapper;
using GerenciadorDeCinema.Dominio.Filmes;
using GerenciadorDeCinema.WebApi.ViewModels.ModuloFilme;

namespace GerenciadorDeCinema.WebApi.Config.AutoMapperConfig
{
    public class FilmeProfile : AppProfileBase
    {
        public FilmeProfile()
        {
            ConverterDeEntidadeParaViewModel();
            ConverterDeViewModelParaEntidade();
        }

        private void ConverterDeEntidadeParaViewModel()
        {
            CreateMap<Filme, FormsFilmeViewModel>();
            CreateMap<Filme, InserirFilmeViewModel>()
                .ForMember(destino => destino.Duracao, opt => opt.MapFrom(origem => origem.Duracao.ToString(@"hh\:mm\:ss")));

            CreateMap<Filme, ListarFilmeViewModel>()
                .ForMember(destino => destino.Duracao, opt => opt.MapFrom(origem => origem.Duracao.ToString(@"hh\:mm\:ss")));
        }

        private void ConverterDeViewModelParaEntidade()
        {
            CreateMap<InserirFilmeViewModel, Filme>()
                .ForMember(destino => destino.Id, opt => opt.Ignore());           

            CreateMap<FormsFilmeViewModel, Filme>();

            CreateMap<EditarFilmeViewModel, Filme>()
                .ForMember(d => d.Id, opt => opt.Ignore());
        }
    }
}
