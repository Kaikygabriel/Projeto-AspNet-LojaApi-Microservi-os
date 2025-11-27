using MediatorX.Core.DependencyInjection;
using Shop.Cart.Application.UseCases.Cart.Commands.Create;
using Shop.Cart.Domain.Interfaces;
using Shop.Cart.Domain.Interfaces.Product;
using Shop.Cart.Infra.Repository;
using Shop.Cart.Infra.Repository.Product;

namespace Shop.Cart.Api.Extesions;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICartRepository, RepositoryCart>();
        services.AddScoped<IProductRepository,RepositoryProduct>();
        services.AddScoped<ICartItemRepository,RepositoryCartItem>();
        services.AddMediator(typeof(CreateCartCommand).Assembly);
        
        return services;
    }
}