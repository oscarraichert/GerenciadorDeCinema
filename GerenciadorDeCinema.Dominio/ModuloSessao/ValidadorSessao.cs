using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Dominio.ModuloSessao
{
    public class ValidadorSessao : AbstractValidator<Sessao>
    {
        public ValidadorSessao()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("O campo data é obrigatório")
                .NotEmpty().WithMessage("O campo data é obrigatório")
                .GreaterThanOrEqualTo((x) => DateTime.Now).WithMessage("A sessão não pode ser em uma data passada");

            RuleFor(x => x.HorarioInicio)
                .NotNull().WithMessage("O campo horario início é obrigatório")
                .NotEmpty().WithMessage("O campo horario início é obrigatório");

            RuleFor(x => x.HorarioFim)
               .NotNull().WithMessage("O campo horario do fim é obrigatório")
               .NotEmpty().WithMessage("O campo horario do fim é obrigatório");

            RuleFor(x => x.ValorIngresso)
                .NotNull().WithMessage("O campo valor do ingresso é obrigatório")
                .NotEmpty().WithMessage("O campo valor do ingresso é obrigatório");

            RuleFor(x => x.TipoAnimacao)
                .NotNull().WithMessage("O campo tipo de animação é obrigatório")
                .NotEmpty().WithMessage("O campo tipo de animação é obrigatório");

            RuleFor(x => x.TipoAudio)
                .NotNull().WithMessage("O campo tipo de audio é obrigatório")
                .NotEmpty().WithMessage("O campo tipo de audio é obrigatório");
        }
    }
}
