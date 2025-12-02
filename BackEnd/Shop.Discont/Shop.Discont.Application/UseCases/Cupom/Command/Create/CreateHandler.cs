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
            await _repository.Create(request.Cupom);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}