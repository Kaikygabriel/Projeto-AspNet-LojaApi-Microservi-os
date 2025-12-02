using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Product.Command.Delete;

public class DeleteProductHandler : HandlerBase,
    IRequestHandler<DeleteProductCommand,bool>
{
    private const string ProductsMemoryCacheKey = "Products";
    private readonly IMemoryCache _memoryCache;
    public DeleteProductHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache) : base(unitOfWork)
    {
        _memoryCache = memoryCache;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _memoryCache.Remove(ProductsMemoryCacheKey);
            UnitOfWork.RepositoryProduct.Delete(request.Product);
            await UnitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}