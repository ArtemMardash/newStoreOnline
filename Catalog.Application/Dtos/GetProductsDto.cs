using Catalog.Application.Dtos.Responses;
using MediatR;

namespace Catalog.Application.Dtos;

public class GetProductsDto: IRequest<ProductsListDto>
{
    /// <summary>
    /// Category of product
    /// </summary>
    public string Category { get; set; }
}