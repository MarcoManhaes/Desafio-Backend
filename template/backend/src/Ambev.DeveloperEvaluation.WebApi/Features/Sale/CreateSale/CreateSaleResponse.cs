using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

public class CreateSaleResponse
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public SaleStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<CreateSaleItemResponse> Items { get; set; } = new();
}