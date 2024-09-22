using Billing.Application.Dtos;
using Billing.Application.Interfaces;
using MediatR;

namespace Billing.Application.RequestHandlers;

public class UpdateBillRequestHandler: IRequestHandler<UpdateBillDto>
{
    private readonly IBillingRepository _billRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBillRequestHandler(IBillingRepository billRepository, IUnitOfWork unitOfWork)
    {
        _billRepository = billRepository;
        _unitOfWork = unitOfWork;
    }
    
    /// <summary>
    /// Method to update bill
    /// </summary>
    public async Task Handle(UpdateBillDto request, CancellationToken cancellationToken)
    {
        var bill = await _billRepository.GetBillByIdAsync(request.BillSystemId, cancellationToken);
        bill.ChangeStatus(request.NewStatus);
        await _billRepository.UpdateBillingAsync(bill, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}