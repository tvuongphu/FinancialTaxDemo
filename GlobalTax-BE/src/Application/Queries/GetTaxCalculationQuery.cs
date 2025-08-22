using MediatR;
using Microsoft.EntityFrameworkCore;
using GlobalTax.Application.Interfaces;
using GlobalTax.Application.Models;

namespace GlobalTax.Application.Queries;

public record GetTaxCalculationQuery(string country, decimal income) : IRequest<TaxDetailDto>;

//public class GetTaxCalculationQueryHandler(
//    ITaxService taxService
//) : IRequestHandler<GetTaxCalculationQuery, TaxDetailDto>
//{
//    public async Task<TaxDetailDto> Handle(GetTaxCalculationQuery request, CancellationToken cancellationToken)
//    {
//        return await taxService.CalculateTax(request.country, request.income);
//    }
//}