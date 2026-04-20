using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Result returned when retrieving a sale.
/// </summary>
public class GetSaleResult
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int BranchId { get; set; }
    public string BranchName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public SaleStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<GetSaleItemResult> Items { get; set; } = new();
}