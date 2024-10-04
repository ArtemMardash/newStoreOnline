using Billing.Application.Dtos;
using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;
using MediatR;

namespace Billing.Application.RequestHandlers;

public class CreateBillRequestHandler: IRequestHandler<CreateBillDto>
{
    private readonly IBillingRepository _billRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    
    public CreateBillRequestHandler(IBillingRepository billRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _billRepository = billRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }
    
    /// <summary>
    /// Method to create bill
    /// </summary>
    public async Task Handle(CreateBillDto request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.SystemUserId, cancellationToken);
        var bill = new Bill(user.Id, request.OrderId, request.Status, request.TotalPrice);
        await _billRepository.AddBillingAsync(bill, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}