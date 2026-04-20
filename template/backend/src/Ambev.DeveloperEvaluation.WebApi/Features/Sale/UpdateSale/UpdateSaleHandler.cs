using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Handler responsável por atualizar uma venda
/// </summary>
public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateSaleHandler> _logger;

    public UpdateSaleHandler(
        ISaleRepository saleRepository,
        IMapper mapper,
        ILogger<UpdateSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<UpdateSaleResult> Handle(
        UpdateSaleCommand command,
        CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);

        if (sale == null)
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found");

        if (sale.Status == SaleStatus.Cancelled)
            throw new InvalidOperationException("Cancelled sales cannot be updated.");

        sale.Date = command.Date;
        sale.CustomerId = command.CustomerId;
        sale.CustomerName = command.CustomerName;
        sale.BranchId = command.BranchId;
        sale.BranchName = command.BranchName;

        sale.Items.Clear();

        foreach (var item in command.Items)
        {
            sale.Items.Add(new SaleItem(
                item.ProductId,
                item.ProductName,
                item.Quantity,
                item.UnitPrice
            ));
        }

        sale.RecalculateTotal();
        sale.UpdatedAt = DateTime.UtcNow;

        await _saleRepository.UpdateAsync(sale, cancellationToken);

        _logger.LogInformation(
            "SaleModified | SaleId: {SaleId} | NewTotalAmount: {TotalAmount}",
            sale.Id,
            sale.TotalAmount);

        return _mapper.Map<UpdateSaleResult>(sale);
    }
}