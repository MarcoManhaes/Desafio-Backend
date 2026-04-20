using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;

public class CancelSaleValidator : AbstractValidator<CancelSaleRequest>
{
    public CancelSaleValidator()
    {
        // Sem regras obrigatórias no momento
        // Mantido por padrão do template
    }
}