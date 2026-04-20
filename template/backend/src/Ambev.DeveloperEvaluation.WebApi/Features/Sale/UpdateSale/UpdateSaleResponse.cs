using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Response returned after successfully updating a sale
/// </summary>
public class UpdateSaleResponse
{
    public Guid Id { get; set; }

    public int Number { get; set; }

    public decimal TotalAmount { get; set; }

    public SaleStatus Status { get; set; }

    public DateTime UpdatedAt { get; set; }
}