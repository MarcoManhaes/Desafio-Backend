using MediatR;
using Microsoft.Extensions.Logging;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ILogger<CancelSaleHandler> _logger;

    public CancelSaleHandler(
        ISaleRepository saleRepository,
        ILogger<CancelSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _logger = logger;
    }

    public async Task<CancelSaleResult> Handle(
        CancelSaleCommand command,
        CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);

        if (sale == null)
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found.");

        if (sale.Status == SaleStatus.Cancelled)
            throw new InvalidOperationException("Sale is already cancelled.");

        sale.Cancel(); 
        sale.UpdatedAt = DateTime.UtcNow;

        await _saleRepository.UpdateAsync(sale, cancellationToken);

        _logger.LogInformation(
            "SaleCancelled | SaleId: {SaleId}",
            sale.Id);

        return new CancelSaleResult
        {
            Id = sale.Id,
            Status = sale.Status,
            CancelledAt = sale.UpdatedAt!.Value
        };
    }
}