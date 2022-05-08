using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Model.Validacao
{
    public class PedidoItemValidacao : AbstractValidator<PedidoItem>
    {
        public PedidoItemValidacao()
        {
            RuleFor(c => c.Quantidade)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .NotNull();

            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .NotNull();

            RuleFor(c => c.Desconto)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
               .NotNull();
        }
    }
}
