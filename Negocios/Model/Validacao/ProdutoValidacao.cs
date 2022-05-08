using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Model.Validacao
{
    public class ProdutoValidacao : AbstractValidator<Produto>
    {
        public ProdutoValidacao()
        {
            RuleFor(c => c.CodigoBarras)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .NotNull();

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(5, 50).WithMessage("O campo {PropertyName} precisa ter {MinLength} e {MaxLength} caracteres!");

            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .NotNull();

            RuleFor(c => c.TipoProduto)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                 .NotNull();
        }
    }
}