using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Discont.Api.EndPoints.Abstraction;
using Shop.Discont.Application.UseCases.Cupom.Command.Delete;

namespace Shop.Discont.Api.EndPoints.Cupom.EndPoints;

public class MapDeleteCupom : IEndPoint
{
    public static IEndpointRouteBuilder Map(RouteGroupBuilder map)
    {
        map.MapDelete("/", async ([FromServices] IMediator mediator, int id) =>
        {
            var command = new DeleteCommand(id);
            var result = await mediator.Send(command, default);
            return result ? Results.Ok() : Results.BadRequest();
        });
        return map;
    }
}