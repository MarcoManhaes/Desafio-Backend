using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales;

public class ListSalesValidator : AbstractValidator<ListSalesRequest>
{
    public ListSalesValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0);

        RuleFor(x => x.Size)
            .InclusiveBetween(1, 100);
    }
}
