using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Shop.Domain.Interfaces;

namespace Shop.Application.UseCases.Product.Query.GetAll;

public class GetAllProductQueryHandler : HandlerBase,
        IRequestHandler<GetAllProductsQuery,IEnumerable<Domain.Entities.Product>>
{
    private readonly IMemoryCache _memoryCache;
    private const string ProductsMemoryCacheKey = "Products";
        public GetAllProductQueryHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache) : base(unitOfWork)
        {
            _memoryCache = memoryCache;
        }

    public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        if (!_memoryCache.TryGetValue(ProductsMemoryCacheKey, out IEnumerable<Domain.Entities.Product> products))
        {
            products = await UnitOfWork.RepositoryProduct.GetAllAsync();
            var options = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.UtcNow.AddMinutes(3),
                Size = 1,
                SlidingExpiration = TimeSpan.FromMinutes(1.5)
            };
            _memoryCache.Set(ProductsMemoryCacheKey, options);
        }
        return products;
    }
}