using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Model.Validacao
{
    public class PedidoValidacao : AbstractValidator<Pedido>
    {
        public PedidoValidacao()
        {
            RuleFor(c => c.Observacao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(5, 50).WithMessage("O campo {PropertyName} precisa ter {MinLength} e {MaxLength} caracteres!");

            RuleFor(c => c.TipoFrete)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                 .NotNull();

            RuleFor(c => c.Status)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .NotNull();
        }
    }
}
