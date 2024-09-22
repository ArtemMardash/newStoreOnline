using MediatR;

namespace Billing.Application.Dtos;

public class DeleteBillDto: IRequest
{
    /// <summary>
    /// System id of bill
    /// </summary>
    public Guid SystemId { get; set; }
}