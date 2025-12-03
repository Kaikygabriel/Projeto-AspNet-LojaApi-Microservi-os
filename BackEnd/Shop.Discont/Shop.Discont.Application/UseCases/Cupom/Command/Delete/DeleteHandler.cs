using MediatR;
using Shop.Discont.Domain.BackOffice.Interfaces;

namespace Shop.Discont.Application.UseCases.Cupom.Command.Delete;

public class DeleteHandler : HandlerBase,IRequestHandler<DeleteCommand,bool>
{
    public DeleteHandler(IRepositoryCupom repository) : base(repository)
    {
    }

    public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.Id < 0)
                return false;
            var cupom = await _repository.GetByPredicate(x => x.Id == request.Id);
            if (cupom is null)
                return false;
            await _repository.Delete(cupom);
            return true; 
        }
        catch (Exception e)
        {
            return false;
        }
    }
}