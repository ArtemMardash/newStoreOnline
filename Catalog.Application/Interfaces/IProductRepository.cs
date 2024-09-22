using Catalog.Domain.Entities;

namespace Catalog.Application.Interfaces;

public interface IProductRepository
{
    /// <summary>
    /// Method to create a new product
    /// </summary>
    Task CreateAsync(Product product, CancellationToken cancellationToken);

    /// <summary>
    /// Method to return all products of category available
    /// </summary>
    Task<List<Product>> GetProductsAsync(string category, CancellationToken cancellationToken);

    /// <summary>
    /// Method to update info about product
    /// </summary>
    Task UpdateAsync(Product product, CancellationToken cancellationToken);

    Task<Product> GetProductByPublicIdAsync(string publicId, CancellationToken cancellationToken);
}