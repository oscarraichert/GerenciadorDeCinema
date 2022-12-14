using GerenciadorDeCinema.Aplicacao.ViewModels.ModuloSala;
using GerenciadorDeCinema.Dominio.ModuloSala;

namespace GerenciadorDeCinema.WebApi.Config.AutoMapperConfig
{
    public class SalaProfile : AppProfileBase
    {
        public SalaProfile()
        {
            ConverterDeEntidadeParaViewModel();
            ConverterDeViewModelParaEntidade();
        }

        private void ConverterDeEntidadeParaViewModel()
        {
            CreateMap<Sala, ListarSalaViewModel>();
        }

        private void ConverterDeViewModelParaEntidade()
        {
        }
    }
}
