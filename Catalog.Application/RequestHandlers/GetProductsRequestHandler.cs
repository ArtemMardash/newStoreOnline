using Catalog.Application.Dtos;
using Catalog.Application.Dtos.Responses;
using Catalog.Application.Interfaces;
using MediatR;

namespace Catalog.Application.RequestHandlers;

public class GetProductsRequestHandler: IRequestHandler<GetProductsDto, ProductsListDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsRequestHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ProductsListDto> Handle(GetProductsDto request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetProductsAsync(request.Category, cancellationToken);

        return new ProductsListDto
        {
            Products = products.Select(p => new ProductDto
            {
                Name = p.Name,
                Price = p.Price,
                PublicId = p.Id.PublicId,
                Remaining = p.Remaining
            }).ToList()
        };
    }
}