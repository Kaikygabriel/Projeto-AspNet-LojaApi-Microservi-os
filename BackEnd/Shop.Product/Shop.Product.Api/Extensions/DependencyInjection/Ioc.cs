using Shop.Application.UseCases.Category.Command.Create;
using Shop.Domain.Interfaces;
using Shop.Domain.Interfaces.Categorys;
using Shop.Domain.Interfaces.Products;
using Shop.Product.Infra.Repositorys;
using Shop.Product.Infra.Repositorys.Category;
using Shop.Product.Infra.Repositorys.Product;

namespace Shop.Product.Api.Extensions.DependencyInjection;

public static class Ioc
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRepositoryCategory, RepositoryCategory>();
        services.AddScoped<IRepositoryProduct,RepositoryProduct>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddMediatR(x =>
            x.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly));
        
        return services;
    }
}