using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Infrastructure;
using Orders.Application.Dtos;
using Orders.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterPersistence();
builder.Services.AddInfrastracture();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("api/orders/create", async (CreateOrderDto dto,[FromServices] IMediator mediator, CancellationToken cancellationToken) =>
    {
        await mediator.Send(dto, cancellationToken);
    })
    .WithName("CreateOrder")
    .WithTags("Orders")
    .WithOpenApi();

app.MapPut("api/orders/{orderId:guid}/cancel",
    async (Guid orderId, [FromServices]IMediator mediator, CancellationToken cancellationToken) =>
    {
        var dto = new CancelOrderDto
        {
            SystemId = orderId
        };
        await mediator.Send(dto, cancellationToken);
    })
    .WithName("CancelOrder")
    .WithTags("Orders")
    .WithOpenApi();

app.Run();
