using Billing.Application.Dtos;
using Billing.Infrastructure;
using Billing.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastracture();
builder.Services.RegisterPersistence();
builder.Services.RegisterRabbitMq();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

    var context = services.GetService<BillingContext>();
    context?.Database.Migrate();
}

//Method to create a new bill
app.MapPost("/api/bill/create",
        async ([FromBody] CreateBillDto dto, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(dto, cancellationToken);
        })
    .WithName("CreateNewBill")
    .WithTags("Bill")
    .WithOpenApi();

//Method to update bill's data
app.MapPut("/api/bill/update",
        async ([FromBody] UpdateBillDto dto, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(dto, cancellationToken);
        })
    .WithName("UpdateBill")
    .WithTags("Bill")
    .WithOpenApi();

//Method to delete bill
app.MapDelete("/api/bill/delete",
        async ([FromBody] DeleteBillDto dto, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(dto, cancellationToken);
        })
    .WithName("DeleteBill")
    .WithTags("Bill")
    .WithOpenApi();

app.Run();