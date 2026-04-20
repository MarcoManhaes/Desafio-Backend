using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Command for retrieving a sale by its ID.
/// </summary>
public record GetSaleCommand : IRequest<GetSaleResult>
{
    /// <summary>
    /// The unique identifier (GUID) of the sale to retrieve.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Constructor for GetSaleCommand.
    /// </summary>
    /// <param name="id">Sale ID (Guid)</param>
    public GetSaleCommand(Guid id)
    {
        Id = id;
    }
}