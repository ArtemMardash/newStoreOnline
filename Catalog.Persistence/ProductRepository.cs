using Catalog.Application.Interfaces;
using Catalog.Domain;
using Catalog.Domain.Entities;
using Catalog.Domain.ValueObjects;
using Catalog.Persistence.EntitiesDb;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence;

public class ProductRepository : IProductRepository
{
    private readonly CatalogContext _context;

    public ProductRepository(CatalogContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Method to create a new product
    /// </summary>
    public async Task CreateAsync(Product product, CancellationToken cancellationToken)
    {
        var productDb = MapDomainEnityToDb(product);
        await _context.Products.AddAsync(productDb, cancellationToken);
    }

    
    /// <summary>
    /// Method to get products by category
    /// </summary>
    public async Task<List<Product>> GetProductsAsync(string? category, CancellationToken cancellationToken)
    {
        var products = new List<Product>();
        if (string.IsNullOrEmpty(category))
        {
            products = _context.Products.Select(MapDbToDomainEntities).ToList();
        }
        else
        {
            products = (await _context.Products
                .Where(p => p.Category.ToLower() == category.ToLower().Trim())
                .ToListAsync(cancellationToken))
                .Select(MapDbToDomainEntities)
                .ToList();
        }

        return products;
    }

    /// <summary>
    /// Method to update product
    /// </summary>
    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        var productDb = await _context.Products.FirstOrDefaultAsync(p =>p.SystemId == product.Id.SystemId, cancellationToken);
        if (productDb == null)
        {
            throw new InvalidOperationException("There is no bill with such id");
        }

        productDb.Remaning = product.Remaining;
        productDb.Name = product.Name.Trim();
        productDb.Category = product.Category.Trim();
        productDb.Price = product.Price;
        productDb.Unit = (int)product.Unit;

        _context.Products.Update(productDb);
    }

    /// <summary>
    /// Method to get a product by Id
    /// </summary>
    public async Task<Product> GetProductByPublicIdAsync(string publicId, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.PublicId == publicId, cancellationToken);

        if (product == null)
        {
            throw new InvalidOperationException("There is no product with such id");
        }

        return MapDbToDomainEntities(product);
    }
 
    /// <summary>
    /// Mapping from domain entity Product to Db entity ProductDb
    /// </summary>
    private ProductDb MapDomainEnityToDb(Product product)
    {
        return new ProductDb
        {
            SystemId = product.Id.SystemId,
            PublicId = product.Id.PublicId.Trim(),
            Name = product.Name.Trim(),
            Price = product.Price,
            Remaning = product.Remaining,
            Category = product.Category.Trim(),
            Unit = (int)product.Unit
        };
    }

    /// <summary>
    /// Mapping from db entity ProductDb to domain entity Product
    /// </summary>
    /// <param name="productDb"></param>
    /// <returns></returns>
    private Product MapDbToDomainEntities(ProductDb productDb)
    {
        return new Product(new ProductId(productDb.SystemId, productDb.PublicId), productDb.Name, productDb.Price,
            productDb.Remaning, productDb.Category, (Unit)productDb.Unit);
    }
    
}