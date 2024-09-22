using MediatR;

namespace Catalog.Application.Dtos;

public class CreateProductDto : IRequest
{
    
    public string Name { get; set; }
    
    public double Price { get; set; }
    
    public int Remaning { get; set; }
    
    public string Category { get; set; }
    
    public int Unit { get; set; }
}