using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale
{
    public class CreateSaleItemValidator : AbstractValidator<CreateSaleItemRequest>
    {
        public CreateSaleItemValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Quantity).InclusiveBetween(1, 20);
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
        }
    }
}
