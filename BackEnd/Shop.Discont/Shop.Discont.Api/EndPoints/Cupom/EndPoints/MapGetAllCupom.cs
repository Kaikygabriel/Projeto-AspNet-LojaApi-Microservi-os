using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Discont.Api.EndPoints.Abstraction;
using Shop.Discont.Application.UseCases.Cupom.Query.GetAllQuery;

namespace Shop.Discont.Api.EndPoints.Cupom.EndPoints;

public class MapGetAllCupom : IEndPoint
{
    public static IEndpointRouteBuilder Map(RouteGroupBuilder map)
    {
        map.MapGet("/", async ([FromServices] IMediator Mediator) =>
        {
            var query = new GetAllQuery();
            return Results.Ok(await Mediator.Send(query));
        });
        return map;
    }
}