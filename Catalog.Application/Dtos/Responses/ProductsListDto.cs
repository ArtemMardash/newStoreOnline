using MediatR;

namespace Catalog.Application.Dtos.Responses;

public class ProductsListDto
{
    /// <summary>
    /// List of products
    /// </summary>
    public List<ProductDto> Products { get; set; }
}

public class ProductDto
{
    /// <summary>
    /// Public id of product
    /// </summary>
    public string PublicId { get; set; }

    /// <summary>
    /// Name of product
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Price of product
    /// </summary>
    public double Price { get; set; }
    
    /// <summary>
    /// Remaining of product
    /// </summary>
    public int Remaining { get; set; }
}