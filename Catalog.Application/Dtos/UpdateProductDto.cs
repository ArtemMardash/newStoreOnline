using MediatR;

namespace Catalog.Application.Dtos;

public class UpdateProductDto : IRequest
{
    /// <summary>
    /// Public Id of product
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
    public int Remaning { get; set; }
    
    /// <summary>
    /// Category of product
    /// </summary>
    public string Category { get; set; }
    
    /// <summary>
    /// Type of unit of product
    /// </summary>
    public int Unit { get; set; }
}