using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

public class ListSalesCommand : IRequest<ListSalesResult>
{
    public int Page { get; set; }
    public int Size { get; set; }

    public string? Order { get; set; }
    public int? CustomerId { get; set; }
    public int? BranchId { get; set; }
}