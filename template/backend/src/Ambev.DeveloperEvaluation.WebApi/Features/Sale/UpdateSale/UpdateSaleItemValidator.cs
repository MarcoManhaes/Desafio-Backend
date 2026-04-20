using Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleItemValidator : AbstractValidator<UpdateSaleItemRequest>
    {
        public UpdateSaleItemValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Quantity)
                .InclusiveBetween(1, 20);

            RuleFor(x => x.UnitPrice)
                .GreaterThanOrEqualTo(0);
        }
    }
}