using SharedKernal;

namespace Orders.Application.Interfaces;

public interface IBillStatusChangedUseCase
{
    /// <summary>
    /// Method to update bill
    /// </summary>
    Task ExecuteAsync(IBillUpdated billUpdated, CancellationToken cancellationToken);
}