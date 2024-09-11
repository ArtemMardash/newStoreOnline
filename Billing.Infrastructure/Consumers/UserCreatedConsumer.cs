using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;
using MassTransit;
using SharedKernal;

namespace Billing.Infrastructure.Consumers;

public class UserCreatedConsumer : IConsumer<IUserCreated>
{
    private readonly IUserCreatedUseCase _userCreatedUseCase;

    /// <summary>
    /// Constructor to implement use case
    /// </summary>
    public UserCreatedConsumer(IUserCreatedUseCase userCreatedUseCase)
    {
        _userCreatedUseCase = userCreatedUseCase;
    }

    /// <summary>
    /// Add table user to DB bill
    /// </summary>
    public async Task Consume(ConsumeContext<IUserCreated> context)
    {
        var newUser = context.Message;
        var user = new User(new UserId(newUser.Id, newUser.PublicId), newUser.Email, newUser.PhoneNumber,
            newUser.FirstName, newUser.LastName);
        await _userCreatedUseCase.ExecuteAsync(user, CancellationToken.None);
    }
}