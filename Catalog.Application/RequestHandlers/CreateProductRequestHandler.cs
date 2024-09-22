using Catalog.Application.Dtos;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using MediatR;
using Unit = Catalog.Domain.Unit;

namespace Catalog.Application.RequestHandlers;

public class CreateProductRequestHandler : IRequestHandler<CreateProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductRequestHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateProductDto request, CancellationToken cancellationToken)
    {
        await _productRepository.CreateAsync(new Product(request.Name, request.Price, request.Remaning, request.Category,
            (Unit)request.Unit), cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}