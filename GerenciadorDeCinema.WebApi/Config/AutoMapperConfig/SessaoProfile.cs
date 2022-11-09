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

        }

        private void ConverterDeViewModelParaEntidade()
        {
            CreateMap<InserirSessaoViewModel, Sessao>()
                .ForMember(destino => destino.Id, opt => opt.Ignore());
        }
    }
}
