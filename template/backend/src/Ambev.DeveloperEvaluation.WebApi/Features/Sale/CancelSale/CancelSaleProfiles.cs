using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class CancelSaleProfiles : Profile
{
    public CancelSaleProfiles()
    {
        CreateMap<CancelSaleResult, CancelSaleResponse>();
    }
}