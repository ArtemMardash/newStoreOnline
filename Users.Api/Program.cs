using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Application.Dtos;
using Users.Infrastructure;
using Users.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterPersistence();
builder.Services.AddInfrastracture();
builder.Services.RegisterRabbitMq();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetService<Context>();
    context?.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/storeOnline/users/{id:guid}/User",
        async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
    {
        return await mediator.Send(new GetUserDto { Id = id }, cancellationToken);
    })
    .WithName("GetUserByID")
    .WithTags("Users")
    .WithOpenApi();

app.MapPost("/api/storeOnline/users/create",
        async ([FromBody] CreateUserDto dto, IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(dto, cancellationToken);
        })
    .WithName("CreateUser")
    .WithTags("Users")
    .WithOpenApi();

app.MapPut("/api/storeOnline/users/update",
        async ([FromBody] EditUserDto dto, IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.Send(dto, cancellationToken);
        })
    .WithName("EditUser")
    .WithTags("Users")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}