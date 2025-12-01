using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Product.Command.Create;

public class CreateProductHandler :HandlerBase ,IRequestHandler<CreateProductCommand,bool>
{
    private const string ProductsMemoryCacheKey = "Products";
    private readonly IMemoryCache _memoryCache;
    public CreateProductHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache) : base(unitOfWork)
    {
        _memoryCache = memoryCache;
    }

    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _memoryCache.Remove(ProductsMemoryCacheKey);
            var productExisting = 
                await UnitOfWork.RepositoryProduct.GetByPredicate(x => x.Name == request.Product.Name); 
            if(productExisting is not null)
                return false;
                
            UnitOfWork.RepositoryProduct.Create(request.Product);
            await UnitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }   
    }
}