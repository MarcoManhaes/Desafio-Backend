using Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Request para atualização de uma venda
/// </summary>
public class UpdateSaleRequest
{
    public DateTime Date { get; set; }

    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;

    public int BranchId { get; set; }
    public string BranchName { get; set; } = string.Empty;

    public List<UpdateSaleItemRequest> Items { get; set; } = new();
}

