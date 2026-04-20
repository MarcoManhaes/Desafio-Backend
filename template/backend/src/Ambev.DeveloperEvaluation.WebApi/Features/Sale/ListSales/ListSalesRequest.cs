namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales;

/// <summary>
/// Request para listagem de vendas com paginação
/// </summary>
public class ListSalesRequest
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;

    // opcionais
    public string? Order { get; set; }
    public int? CustomerId { get; set; }
    public int? BranchId { get; set; }
}
