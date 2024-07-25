using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;
using MassTransit;
using SharedKernal;

namespace Billing.BackGroundJobs.Consumers;

public class UserCreatedConsumer : IConsumer<IUserCreated>
{
    private readonly IUserCreatedUseCase _userCreatedUseCase;

    public UserCreatedConsumer(IUserCreatedUseCase userCreatedUseCase)
    {
        _userCreatedUseCase = userCreatedUseCase;
    }

    public async Task Consume(ConsumeContext<IUserCreated> context)
    {
        var newUser = context.Message;
        var user = new User(new UserId(newUser.Id, newUser.PublicId), newUser.Email, newUser.PhoneNumber,
            newUser.FirstName, newUser.LastName);
        await _userCreatedUseCase.ExecuteAsync(user, CancellationToken.None);
    }
}