using MediatR;

namespace Catalog.Application.Dtos;

public class CreateProductDto : IRequest
{
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
    
    /// <summary>
    /// Category of product
    /// </summary>
    public string Category { get; set; }
    
    /// <summary>
    /// Type units of product
    /// </summary>
    public int Unit { get; set; }
}