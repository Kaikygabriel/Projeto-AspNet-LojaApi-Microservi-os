using Shop.Discont.Domain.BackOffice.Interfaces;

namespace Shop.Discont.Application.UseCases.Cupom;

public abstract class HandlerBase
{
    protected readonly IRepositoryCupom _repository;

    public HandlerBase(IRepositoryCupom repository)
    {
        _repository = repository;
    }
}