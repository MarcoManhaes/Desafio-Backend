using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.ListSales;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

public class ListSalesHandler : IRequestHandler<ListSalesCommand, ListSalesResult>
{
    private readonly ISaleRepository _saleRepository;

    public ListSalesHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<ListSalesResult> Handle(
        ListSalesCommand command,
        CancellationToken cancellationToken)
    {
        var query = _saleRepository.Query();

        if (command.CustomerId.HasValue)
            query = query.Where(x => x.CustomerId == command.CustomerId.Value);

        if (command.BranchId.HasValue)
            query = query.Where(x => x.BranchId == command.BranchId.Value);

        var totalItems = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderByDescending(x => x.Date)
            .Skip((command.Page - 1) * command.Size)
            .Take(command.Size)
            .Select(x => new ListSaleItemResult
            {
                Id = x.Id,
                Number = x.Number,
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                TotalAmount = x.TotalAmount,
                Status = x.Status,
                Date = x.Date
            })
            .ToListAsync(cancellationToken);

        return new ListSalesResult
        {
            Items = items,
            TotalItems = totalItems,
            CurrentPage = command.Page,
            TotalPages = (int)Math.Ceiling(totalItems / (double)command.Size)
        };
    }
}
