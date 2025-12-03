using Shop.Discont.Api.EndPoints.Cupom.EndPoints;

namespace Shop.Discont.Api.EndPoints.Cupom.MapCupomExtesion;

public static class MapCupomExtensions
{
    public static WebApplication MapCupom(this WebApplication app)
    {
        var group = app.MapGroup("Cupom/").RequireAuthorization();

        MapPostCupom.Map(group);
        MapGetAllCupom.Map(group);
        MapDeleteCupom.Map(group);
        
        return app;
    }

}