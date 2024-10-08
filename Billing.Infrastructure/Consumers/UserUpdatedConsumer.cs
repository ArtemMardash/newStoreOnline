using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;
using MassTransit;
using SharedKernal;

namespace Billing.Infrastructure.Consumers;

public class UserUpdatedConsumer : IConsumer<IUserEdited>
{
    private readonly IUserUpdatedUseCase _useCase;

    /// <summary>
    /// Constructor to implement use case
    /// </summary>
    public UserUpdatedConsumer(IUserUpdatedUseCase useCase)
    {
        _useCase = useCase;
    }

    /// <summary>
    /// Edit user in DB bill
    /// </summary>
    public async Task Consume(ConsumeContext<IUserEdited> context)
    {
        var updatedUser = context.Message;
        var user = new User(new UserId(updatedUser.Id, updatedUser.PublicId), updatedUser.Email,
            updatedUser.PhoneNumber, updatedUser.FirstName, updatedUser.LastName);
        await _useCase.ExecuteAsync(user, CancellationToken.None);
    }
}