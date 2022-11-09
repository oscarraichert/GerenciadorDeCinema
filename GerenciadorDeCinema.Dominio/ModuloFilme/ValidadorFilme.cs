using FluentValidation;
using GerenciadorDeCinema.Dominio.Filmes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCinema.Dominio.ModuloFilme
{
    public class ValidadorFilme: AbstractValidator<Filme>
    {
        public ValidadorFilme()
        {
            RuleFor(x => x.Imagem)
                .NotNull().WithMessage("O campo imagem é obrigatório")
                .NotEmpty().WithMessage("O campo imagem é obrigatório");
            
            RuleFor(x => x.Titulo)
                .NotNull().WithMessage("O campo título é obrigatório")
                .NotEmpty().WithMessage("O campo título é obrigatório");

            RuleFor(x => x.Descricao)
                .NotNull().WithMessage("O campo descrição é obrigatório")
                .NotEmpty().WithMessage("O campo descrição é obrigatório");

            RuleFor(x => x.Duracao)
                .NotNull().WithMessage("O campo duração é obrigatório")
                .NotEmpty().WithMessage("O campo duração é obrigatório");
        }
    }
}
