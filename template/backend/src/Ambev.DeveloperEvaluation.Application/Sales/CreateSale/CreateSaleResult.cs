using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
/// <summary>
/// Result returned after creating a new sale.
/// </summary>
public class CreateSaleResult
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int BranchId { get; set; }
    public string BranchName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public SaleStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}