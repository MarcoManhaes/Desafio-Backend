using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Resultado da atualização da venda
/// </summary>
public class UpdateSaleResult
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public decimal TotalAmount { get; set; }
    public SaleStatus Status { get; set; }
    public DateTime UpdatedAt { get; set; }
}