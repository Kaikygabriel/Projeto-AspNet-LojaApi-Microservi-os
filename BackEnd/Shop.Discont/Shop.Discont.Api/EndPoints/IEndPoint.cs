namespace Shop.Discont.Api.EndPoints.Abstraction;

public interface IEndPoint
{
    static abstract IEndpointRouteBuilder Map( RouteGroupBuilder map);
}