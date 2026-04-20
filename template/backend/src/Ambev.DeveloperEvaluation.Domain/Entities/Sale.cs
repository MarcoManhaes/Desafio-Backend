using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int BranchId { get; set; }
    public string BranchName { get; set; } = string.Empty;
    public List<SaleItem> Items { get; set; } = new();
    public decimal TotalAmount { get; set; }
    public SaleStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Sale()
    {
        Status = SaleStatus.Active;
        Date = DateTime.UtcNow;
        CreatedAt = DateTime.UtcNow;
    }

    public Sale(
        int number,
        DateTime date,
        int customerId,
        string customerName,
        int branchId,
        string branchName,
        List<SaleItem> items)
    {
        if (items == null || !items.Any())
            throw new DomainException("A venda deve possuir pelo menos um item.");

        Id = Guid.NewGuid();
        Number = number;
        Date = date;
        CustomerId = customerId;
        CustomerName = customerName;
        BranchId = branchId;
        BranchName = branchName;
        Items = items;
        Status = SaleStatus.Active;
        CreatedAt = DateTime.UtcNow;
        RecalculateTotal();
    }

    public void Cancel()
    {
        Status = SaleStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddItem(SaleItem item)
    {
        Items.Add(item);
        RecalculateTotal();
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveItem(Guid itemId)
    {
        var item = Items.FirstOrDefault(i => i.Id == itemId);
        if (item != null)
        {
            item.Cancel();
            RecalculateTotal();
            UpdatedAt = DateTime.UtcNow;
        }
    }

    public void RecalculateTotal()
    {
        TotalAmount = Items.Where(i => i.Status == SaleItemStatus.Active)
                           .Sum(i => i.TotalPrice);
    }
}