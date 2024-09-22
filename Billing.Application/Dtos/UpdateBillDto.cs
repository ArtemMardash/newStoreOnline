using Billing.Domain;
using MediatR;

namespace Billing.Application.Dtos;

public class UpdateBillDto: IRequest
{
    /// <summary>
    /// System id of bill
    /// </summary>
    public Guid BillSystemId { get; set; }
    
    /// <summary>
    /// Status to change
    /// </summary>
    public BillStatus NewStatus { get; set; }
}