using MediatR;
using Shop.Discont.Application.UseCases.Cupom.Query.GetByName;
using Shop.Discont.Domain.BackOffice.Interfaces;

namespace Shop.Discont.Application.UseCases.Cupom.Query.GetAllQuery;

public class GetAllQueryHandler : HandlerBase, 
                                IRequestHandler<GetAllQuery,IEnumerable<Domain.BackOffice.Entitites.Cupom?>>
{
    public GetAllQueryHandler(IRepositoryCupom repository) : base(repository)
    {
    }

    public async Task<IEnumerable<Domain.BackOffice.Entitites.Cupom?>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}