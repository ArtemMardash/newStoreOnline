using MediatR;

namespace Catalog.Application.Dtos.Responses;

public class ProductsListDto
{
    public List<ProductDto> Products { get; set; }
}

public class ProductDto
{
    public string PublicId { get; set; }

    public string Name { get; set; }
    
    public double Price { get; set; }
    
    public int Remaining { get; set; }
}