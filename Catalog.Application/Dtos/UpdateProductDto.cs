using MediatR;

namespace Catalog.Application.Dtos;

public class UpdateProductDto : IRequest
{
    public string PublicId { get; set; }
    
    public string Name { get; set; }
    
    public double Price { get; set; }
    
    public int Remaning { get; set; }
    
    public string Category { get; set; }
    
    public int Unit { get; set; }
}