using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure;
using Orders.Application.Dtos;
using Orders.Application.Interfaces;
using Orders.Persistence;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["DbConnectionString"] ??
                       builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterPersistence(connectionString);
builder.Services.AddInfrastructure();
builder.Services.RegisterRabbitMq();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetService<OrderContext>();
    context?.Database.Migrate();
}


// Method to create a new order
app.MapPost("api/orders/create",
        async (CreateOrderDto dto, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(dto, cancellationToken);
        })
    .WithName("CreateOrder")
    .WithTags("Orders")
    .WithOpenApi();

// Method to update order status
app.MapPut("api/orders/{orderId:guid}/status/{newStatus:int}",
        async (Guid orderId, int newStatus, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            var dto = new UpdateOrderDto
            {
                SystemId = orderId,
                NewStatus = newStatus
            };
            await mediator.Send(dto, cancellationToken);
        })
    .WithName("UpdateOrderStatus")
    .WithTags("Orders")
    .WithOpenApi();

// Method to get order by Id
app.MapGet("api/orders/getById",
        async (Guid systemId, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            var dto = new GetOrderByIdDto
            {
                SystemId = systemId
            };
            return mediator.Send(dto, cancellationToken);
        })
    .WithName("GetOrderById")
    .WithTags("Orders")
    .WithOpenApi();
app.Run();