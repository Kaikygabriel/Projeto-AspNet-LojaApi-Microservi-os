using Shop.Cart.Domain.Interfaces;

namespace Shop.Cart.Application.UseCases;

public abstract class HandlerBase
{
    protected readonly IUnitOfWork _unitOfWork;

    protected HandlerBase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}