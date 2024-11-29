using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Application.Dtos;
using Users.Infrastructure;
using Users.Persistence;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["DbConnectionString"] ??
                       builder.Configuration.GetConnectionString("DefaultConnection");
var rabbitHost = builder.Configuration.GetConnectionString("RabbitHost");
var rabbitPort = builder.Configuration.GetConnectionString("RabbitPort");
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.RegisterPersistence(connectionString);
builder.Services.AddInfrastracture();
builder.Services.RegisterRabbitMq(rabbitPort, rabbitHost);

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetService<UserContext>();
    context?.Database.Migrate();
}

app.UseCors(x =>
{
    x.AllowAnyMethod();
    x.AllowAnyHeader();
    x.AllowAnyOrigin();
});

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetService<UserContext>();
    context?.Database.Migrate();
}


app.MapGet("/api/storeOnline/users/{id:guid}/User",
        async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(new GetUserDto { Id = id }, cancellationToken);
            return result == null ? Results.NoContent() : Results.Ok(result);
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