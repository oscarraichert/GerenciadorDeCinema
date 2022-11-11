using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Dominio.ModuloSala
{
    public class ValidadorSala : AbstractValidator<Sala>
    {
        public ValidadorSala()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("O campo nome é obrigatório")
                .NotEmpty().WithMessage("O campo nome é obrigatório");

            RuleFor(x => x.QuantidadeAssentos)
                .NotNull().WithMessage("O campo quantidade de assentos é obrigatório")
                .NotEmpty().WithMessage("O campo quantidade de assentos é obrigatório");
        }
    }
}
