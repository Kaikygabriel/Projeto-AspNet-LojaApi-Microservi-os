using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs.Product;
using Shop.Application.UseCases.Product.Command.Create;
using Shop.Application.UseCases.Product.Command.Delete;
using Shop.Application.UseCases.Product.Query.GetAll;
using Shop.Application.UseCases.Product.Query.GetByName;

namespace Shop.Product.Api.Extensions.Product;

public static class MapProductExtension
{
    public static void MapProducts(this WebApplication app)
    {
        app.MapGet("/Products", async (IMediator mediator) =>
        {
            var query = new GetAllProductsQuery();
            var products = await mediator.Send(query);
            return products is not null
                ? Results.Ok(products)
                : Results.BadRequest("Products not found");
        });
        app.MapGet("/Products/{name:alpha:min(1)}", async 
            (string name,IMediator mediator) =>
        {
            var query = new GetByNameProductQuery(name);
            var product = await mediator.Send(query);
            return product is not null
                ? Results.Ok(product)
                : Results.BadRequest("Product not found");
        });
        app.MapPost("/Products", async
            ([FromBody]ProductDto productDto,IMediator mediator) =>
        {
            var command = new CreateProductCommand((Domain.Entities.Product)productDto);
            var resultCreate = await mediator.Send(command);
            return resultCreate 
                ? Results.Created()
                : Results.NotFound("Error in create!");
        });
        
        app.MapDelete("/Products/{name:alpha:min(1)}", async 
            (string name,IMediator mediator) =>
        {
            var query = new GetByNameProductQuery(name);
            var product = await mediator.Send(query);
            if(product is null)
                return Results.BadRequest("Product not found");
            var command = new DeleteProductCommand((Domain.Entities.Product)product);
            var result = await mediator.Send(command);
            return result 
                ? Results.Ok(product)
                : Results.NotFound("Error in delete!");
        });
    }
}