using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases;

public abstract class HandlerBase
{
    protected IUnitOfWork UnitOfWork;

    protected HandlerBase(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}