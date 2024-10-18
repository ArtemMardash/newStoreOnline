using SharedKernal;

namespace Orders.Application.Interfaces;

public interface IBillStatusChangedUseCase
{
    Task ExecuteAsync(IBillUpdated billUpdated, CancellationToken cancellationToken);
}