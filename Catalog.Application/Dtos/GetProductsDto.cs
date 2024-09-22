using Catalog.Application.Dtos.Responses;
using MediatR;

namespace Catalog.Application.Dtos;

public class GetProductsDto: IRequest<ProductsListDto>
{
    public string Category { get; set; }
}