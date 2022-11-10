using GerenciadorDeCinema.Dominio.ModuloSessao;
using GerenciadorDeCinema.WebApi.ViewModels.ModuloSessao;

namespace GerenciadorDeCinema.WebApi.Config.AutoMapperConfig
{
    public class SessaoProfile : AppProfileBase
    {
        public SessaoProfile()
        {
            ConverterDeEntidadeParaViewModel();
            ConverterDeViewModelParaEntidade();
        }

        private void ConverterDeEntidadeParaViewModel()
        {
            CreateMap<Sessao, FormsSessaoViewModel>();

            CreateMap<Sessao, InserirSessaoViewModel>()
                .ForMember(destino => destino.HorarioInicio, opt => opt.MapFrom(origem => origem.HorarioInicio.ToString(@"hh\:mm\:ss")));

            CreateMap<Sessao, ListarSessaoViewModel>()
                .ForMember(destino => destino.HorarioInicio, opt => opt.MapFrom(origem => origem.HorarioInicio.ToString(@"hh\:mm\:ss")));

            CreateMap<Sessao, VisualizarSessaoCompletaViewModel>()
                .ForMember(destino => destino.HorarioInicio, opt => opt.MapFrom(origem => origem.HorarioInicio.ToString(@"hh\:mm\:ss")))
                .ForMember(destino => destino.HorarioFim, opt => opt.MapFrom(origem => origem.HorarioFim.ToString(@"hh\:mm\:ss")));
        }

        private void ConverterDeViewModelParaEntidade()
        {
            CreateMap<InserirSessaoViewModel, Sessao>()
                .ForMember(destino => destino.Id, opt => opt.Ignore());

            CreateMap<VisualizarSessaoViewModel, Sessao>();
        }
    }
}
