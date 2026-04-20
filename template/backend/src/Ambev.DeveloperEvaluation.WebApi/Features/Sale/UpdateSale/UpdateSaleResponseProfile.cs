using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class UpdateSaleResponseProfile : Profile
{
    public UpdateSaleResponseProfile()
    {
        CreateMap<UpdateSaleResult, UpdateSaleResponse>();
    }
}