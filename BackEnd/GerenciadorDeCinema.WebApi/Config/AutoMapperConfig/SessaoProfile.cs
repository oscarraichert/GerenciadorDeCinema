using GerenciadorDeCinema.Dominio.Compartilhado;
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
                .ForMember(destino => destino.HorarioInicio, opt => opt.MapFrom(origem => origem.HorarioInicio.ToString(@"hh\:mm\:ss")))
                .ForMember(destino => destino.TituloFilme, opt => opt.MapFrom(origem => origem.Filme.Titulo));

            CreateMap<Sessao, VisualizarSessaoCompletaViewModel>()
                .ForMember(destino => destino.HorarioInicio, opt => opt.MapFrom(origem => origem.HorarioInicio.ToString(@"hh\:mm\:ss")))
                .ForMember(destino => destino.HorarioFim, opt => opt.MapFrom(origem => origem.HorarioFim.ToString(@"hh\:mm\:ss")))
                .ForMember(destino => destino.TituloFilme, opt => opt.MapFrom(origem => origem.Filme.Titulo))
                .ForMember(destino => destino.NomeSala, opt => opt.MapFrom(origem => origem.Sala.Nome))
                .ForMember(destino => destino.TipoAnimacao, opt => opt.MapFrom(origem => origem.TipoAnimacao.GetDescription()))
                .ForMember(destino => destino.TipoAudio, opt => opt.MapFrom(origem => origem.TipoAudio.GetDescription()));
        }

        private void ConverterDeViewModelParaEntidade()
        {
            CreateMap<InserirSessaoViewModel, Sessao>()
                .ForMember(destino => destino.Id, opt => opt.Ignore());

            CreateMap<VisualizarSessaoViewModel, Sessao>();

            CreateMap<VisualizarSessaoCompletaViewModel, Sessao>();
        }
    }
}
