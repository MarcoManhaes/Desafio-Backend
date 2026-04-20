using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Command para atualização de uma venda
/// </summary>
public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    public Guid Id { get; set; }   // vem da rota

    public DateTime Date { get; set; }

    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;

    public int BranchId { get; set; }
    public string BranchName { get; set; } = string.Empty;

    public List<UpdateSaleItemCommand> Items { get; set; } = new();
}

