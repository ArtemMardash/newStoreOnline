using Billing.Application.Dtos;
using Billing.Application.Interfaces;
using MediatR;

namespace Billing.Application.RequestHandlers;

public class DeleteBillRequestHandler: IRequestHandler<DeleteBillDto>
{
    private readonly IBillingRepository _billingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBillRequestHandler(IBillingRepository billingRepository, IUnitOfWork unitOfWork)
    {
        _billingRepository = billingRepository;
        _unitOfWork = unitOfWork;
    }
    
    /// <summary>
    /// Method to delete bill
    /// </summary>
    public async Task Handle(DeleteBillDto request, CancellationToken cancellationToken)
    {
        var bill = await _billingRepository.GetBillByIdAsync(request.SystemId, cancellationToken);
        await _billingRepository.DeleteBillingAsync(bill.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}