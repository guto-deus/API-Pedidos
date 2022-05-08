using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Model.Validacao
{
    public class ClienteValidacao : AbstractValidator<Cliente>
    {
        public ClienteValidacao()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(5, 50).WithMessage("O campo {PropertyName} precisa ter {MinLength} e {MaxLength} caracteres!");

            RuleFor(c => c.CEP)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .MinimumLength(8);

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(5, 50).WithMessage("O campo {PropertyName} precisa ter {MinLength} e {MaxLength} caracteres!");

            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(4, 20).WithMessage("O campo {PropertyName} precisa ter {MinLength} e {MaxLength} caracteres!");
        }
    }
}