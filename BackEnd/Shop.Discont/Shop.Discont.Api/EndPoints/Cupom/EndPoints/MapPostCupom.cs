using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Discont.Api.EndPoints.Abstraction;
using Shop.Discont.Application.UseCases.Cupom.Command.Create;

namespace Shop.Discont.Api.EndPoints.Cupom.EndPoints;

public class MapPostCupom : IEndPoint
{
    public static IEndpointRouteBuilder Map(RouteGroupBuilder group)
    {
        group.MapPost("/",async ([FromServices]IMediator mediator,
            [FromBody]Domain.BackOffice.Entitites.Cupom cupom) =>
        {
            var command = new CreateCommand(cupom);
            var result = await mediator.Send(command);
            return result ? Results.NoContent() : Results.BadRequest();
        });
        return group;
    }
}