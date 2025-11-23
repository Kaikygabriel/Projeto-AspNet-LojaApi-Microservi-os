using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs.Category;
using Shop.Application.UseCases.Category.Command.Create;
using Shop.Application.UseCases.Category.Command.Delete;
using Shop.Application.UseCases.Category.Query.GetAll;
using Shop.Application.UseCases.Category.Query.GetByName;

namespace Shop.Product.Api.Extensions.Category;

public static class MapCategoryExtesion
{
    public static void MapCategory(this WebApplication app)
    {
        app.MapGet("Categorys", async (
            IMediator mediator) =>
        {
            var categorys = await mediator.Send(new GetAllCategoryQuery());
            return categorys is not null ? Results.Ok(categorys) : Results.BadRequest();
        }).RequireAuthorization();

        app.MapGet("Categorys/{name:alpha}", async (
            string name, IMediator mediator) =>
        {
            var category = await mediator.Send(new GetByNameCategoryQuery(name));
            var categoryDto = (CategoryDto)category;
            return Results.Ok(category);
        }).RequireAuthorization();

        app.MapPost("Categorys", async (
            [FromBody] CategoryDto category, IMediator mediator) =>
        {
            var resultCreate =
                await mediator.Send(new CreateCategoryCommand((Domain.Entities.Category)category));
            return resultCreate ? Results.Created() : Results.BadRequest("Error in create !");
        }).RequireAuthorization();

        app.MapDelete("Categorys/{name:alpha}",
            async (
                [FromRoute]string name,
                IMediator mediator) =>
            {
                var category = await mediator.Send(new GetByNameCategoryQuery(name));

                if (category is null)
                    return Results.BadRequest("Category no existing");

                var resultDelete = await mediator.Send(new DeleteCategoryCommand((Domain.Entities.Category)category));
                
                return resultDelete
                    ? Results.Ok(category)
                    : Results.NotFound("Error in delete category");
            }).RequireAuthorization();
    }
}