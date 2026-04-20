using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales;

/// <summary>
/// Response para listagem de vendas
/// </summary>
public class ListSalesResponse
{
    public Guid Id { get; set; }

    public int Number { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }

    public SaleStatus Status { get; set; }

    public DateTime Date { get; set; }
}
