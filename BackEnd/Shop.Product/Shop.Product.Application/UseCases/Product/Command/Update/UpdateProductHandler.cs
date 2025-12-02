using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Product.Command.Update;

public class UpdateProductHandler :HandlerBase ,IRequestHandler<UpdateProductCommand,bool>
{
    private const string ProductsMemoryCacheKey = "Products";
    private readonly IMemoryCache _memoryCache;

    public UpdateProductHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache) : base(unitOfWork)
    {
        _memoryCache = memoryCache;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _memoryCache.Remove(ProductsMemoryCacheKey);
            var userExisting =await UnitOfWork.RepositoryProduct.GetByPredicate(x => x.Name == request.Product.Name);
            if (userExisting is null)
                return false;
            UnitOfWork.RepositoryProduct.Update(request.Product);
            await UnitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }   
    }
}