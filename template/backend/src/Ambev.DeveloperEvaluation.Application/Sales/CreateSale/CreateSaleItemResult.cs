using Ambev.DeveloperEvaluation.Domain.Enums;
using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Result returned after creating an item within a sale.
/// </summary>
public class CreateSaleItemResult
{
    public Guid Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
    public SaleItemStatus Status { get; set; }
}