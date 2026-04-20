using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;

public class GetSaleResponse
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public SaleStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<GetSaleItemResponse> Items { get; set; } = new();
}