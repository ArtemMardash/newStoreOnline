using Billing.Application.Dtos;
using MediatR;

namespace Billing.Application.UseCases;

public class GetBilling: IRequestHandler<GetBillDto>
{
    public Task Handle(GetBillDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}