using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem : BaseEntity
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
    public SaleItemStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public SaleItem()
    {
        Status = SaleItemStatus.Active;
        CreatedAt = DateTime.UtcNow;
    }

    public SaleItem(int productId, string productName, int quantity, decimal unitPrice)
    {
        if (quantity < 1 || quantity > 20)
            throw new DomainException("A quantidade de itens deve ser entre 1 e 20.");

        Id = Guid.NewGuid();
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Status = SaleItemStatus.Active;
        CreatedAt = DateTime.UtcNow;

        ApplyDiscount();
        CalculateTotalPrice();
    }

    public void ApplyDiscount()
    {
        if (Quantity >= 10 && Quantity <= 20)
            Discount = UnitPrice * Quantity * 0.2m;
        else if (Quantity >= 4 && Quantity < 10)
            Discount = UnitPrice * Quantity * 0.1m;
        else
            Discount = 0m;
    }

    public void CalculateTotalPrice()
    {
        TotalPrice = (UnitPrice * Quantity) - Discount;
        if (TotalPrice < 0)
            TotalPrice = 0;
    }

    public void Cancel()
    {
        Status = SaleItemStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;
    }
}
