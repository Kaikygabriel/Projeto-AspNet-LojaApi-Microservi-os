using MediatR;
using Shop.Discont.Domain.BackOffice.Interfaces;

namespace Shop.Discont.Application.UseCases.Cupom.Query.GetByName;

public class GetByNameHandler : HandlerBase, 
                                IRequestHandler<GetByNameQuery,Domain.BackOffice.Entitites.Cupom?>
{
    public GetByNameHandler(IRepositoryCupom repository) : base(repository)
    {
    }

    public async Task<Domain.BackOffice.Entitites.Cupom?> Handle(GetByNameQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Name))
            return null;
        return await _repository.GetByPredicate(x => x.Name == request.Name);
    }
}