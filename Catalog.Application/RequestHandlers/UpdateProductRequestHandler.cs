using Catalog.Application.Dtos;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Domain.ValueObjects;
using MediatR;
using Unit = Catalog.Domain.Unit;

namespace Catalog.Application.RequestHandlers;

public class UpdateProductRequestHandler : IRequestHandler<UpdateProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductRequestHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateProductDto request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductByPublicIdAsync(request.PublicId, cancellationToken);
        product.Unit = (Unit)request.Unit;
        product.Remaining = request.Remaning;
        product.Category = request.Category;
        product.Name = request.Name;
        product.Price = request.Price;
        await _productRepository.UpdateAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}