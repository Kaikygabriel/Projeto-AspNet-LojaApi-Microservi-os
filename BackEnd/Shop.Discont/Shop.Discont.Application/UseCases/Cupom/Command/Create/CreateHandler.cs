using MediatR;
using Shop.Discont.Domain.BackOffice.Interfaces;

namespace Shop.Discont.Application.UseCases.Cupom.Command.Create;

public class CreateHandler : HandlerBase,IRequestHandler<CreateCommand,bool> 
{
    public CreateHandler(IRepositoryCupom repository) : base(repository)
    {
    }

    public async Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (await _repository.GetByPredicate(x => x.Name == request.Cupom.Name) is not null ||
                request.Cupom is null)
                return false;
            await _repository.Create(request.Cupom);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}