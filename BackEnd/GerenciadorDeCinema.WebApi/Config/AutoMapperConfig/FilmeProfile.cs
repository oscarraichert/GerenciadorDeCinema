using AutoMapper;
using GerenciadorDeCinema.Aplicacao.ViewModels.ModuloFilme;
using GerenciadorDeCinema.Dominio.Filmes;

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
            CreateMap<Filme, FormsFilmeViewModel>()
                .ForMember(destino => destino.Id, opt => opt.MapFrom(orig => orig.Id));

            CreateMap<Filme, InserirFilmeViewModel>()
                .ForMember(destino => destino.Duracao, opt => opt.MapFrom(origem => origem.Duracao.ToString(@"hh\:mm\:ss")));

            CreateMap<Filme, VisualizarFilmeViewModel>()
                .ForMember(destino => destino.Duracao, opt => opt.MapFrom(origem => origem.Duracao.ToString(@"hh\:mm\:ss")));

            CreateMap<Filme, ListarFilmeViewModel>()
                .ForMember(destino => destino.Duracao, opt => opt.MapFrom(origem => origem.Duracao.ToString(@"hh\:mm\:ss")));
        }

        private void ConverterDeViewModelParaEntidade()
        {
            CreateMap<InserirFilmeViewModel, Filme>()
                .ForMember(destino => destino.Id, opt => opt.MapFrom(orig => orig.Id));

            CreateMap<FormsFilmeViewModel, Filme>()
                .ForMember(destino => destino.Id, opt => opt.MapFrom(orig => orig.Id));

            CreateMap<EditarFilmeViewModel, Filme>()
                .ForMember(destino => destino.Id, opt => opt.MapFrom(orig => orig.Id));

            CreateMap<VisualizarFilmeViewModel, Filme>()
                .ForMember(destino => destino.Id, opt => opt.MapFrom(orig => orig.Id));

            CreateMap<EditarFilmeViewModel, VisualizarFilmeViewModel>()
                .ForMember(destino => destino.Id, opt => opt.MapFrom(orig => orig.Id));
        }
    }
}
