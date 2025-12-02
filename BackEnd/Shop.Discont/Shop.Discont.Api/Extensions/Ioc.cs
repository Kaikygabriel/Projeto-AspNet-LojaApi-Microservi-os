using Shop.Discont.Application.UseCases.Cupom;
using Shop.Discont.Domain.BackOffice.Interfaces;
using Shop.Discont.Infra.Data;
using Shop.Discont.Infra.Data.Contracts;
using Shop.Discont.Infra.Repository;

namespace Shop.Discont.Api.Extensions;

public static class Ioc
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddMediatR
            (x => x.RegisterServicesFromAssembly(typeof(HandlerBase).Assembly));
        services.AddScoped<ISqlConnection, SqlConnectionService>();
        services.AddScoped<IRepositoryCupom, CupomRepository>();
        return services;
    }
}