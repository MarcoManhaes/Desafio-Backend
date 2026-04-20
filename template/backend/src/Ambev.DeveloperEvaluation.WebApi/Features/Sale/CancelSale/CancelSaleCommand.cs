using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Command para cancelamento de uma venda
/// </summary>
public class CancelSaleCommand : IRequest<CancelSaleResult>
{
    public Guid Id { get; set; }
}