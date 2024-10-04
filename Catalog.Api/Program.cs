using Catalog.Application;
using Catalog.Application.Dtos;
using Catalog.Infrastructure;
using Catalog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastracture();
builder.Services.RegisterPersistence();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetService<CatalogContext>();
    context?.Database.Migrate();
}

    //Method to create a new Product
app.MapPost("/api/Product/create",
        async ([FromBody] CreateProductDto dto, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(dto, cancellationToken);
        })
    .WithName("CreateNewProduct")
    .WithTags("Product")
    .WithOpenApi();

//Method to update product info
app.MapPut("/api/Product/update",
        async ([FromBody] UpdateProductDto dto, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(dto, cancellationToken);
        })
    .WithName("UpdateProduct")
    .WithTags("Product")
    .WithOpenApi();

//Method to get products by categories
app.MapGet("/api/Product/list",
        async (string? category, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            var dto = new GetProductsDto { Category = category };
           var products =  await mediator.Send(dto, cancellationToken);
           return products;
        })
    .WithName("GetProductsByCategory")
    .WithTags("Products")
    .WithOpenApi();

app.Run();

