using MediatorX.Core.Abstraction.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Cart.Application.Dto;
using Shop.Cart.Application.UseCases.Cart.Commands.ApplyItemInCart;
using Shop.Cart.Application.UseCases.Cart.Commands.Create;
using Shop.Cart.Application.UseCases.Cart.Commands.DeleteItemCart;
using Shop.Cart.Application.UseCases.Cart.Query.GetById;
using Shop.Cart.Application.UseCases.Cart.Query.GetByUserId;
using Shop.Cart.Domain.Entities;

namespace Shop.Cart.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CartController  : ControllerBase
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetById")]
    public async Task<ActionResult> GetById(int Id)
    {
        var cart = await _mediator.SendAsync(new GetByIdCartQuery(Id));
        return cart is not null? Ok(cart):  BadRequest("Cart notfound");
    }
    [HttpGet("GetByUserId")]
    public async Task<ActionResult> GetById(string Id)
    {
        var cart = await _mediator.SendAsync(new GetCartByUserIdQuery(Id));
        return cart is not null? Ok(cart):  BadRequest("Cart notfound");
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody]Domain.Entities.Cart cart)
    {
        if (cart is null)
            return BadRequest();
        var result = await _mediator.SendAsync(new CreateCartCommand(cart));
        return result ? Created() : NotFound();
    }
    [HttpPost("AddItemInCart")]
    public async Task<ActionResult> AddItemInCart([FromBody]CartDto cartItem,string id)
    {
        if (cartItem is null )
            return BadRequest();
        var result = await _mediator.SendAsync(new AddItemInCartCommand(cartItem,id));
        return result ? Created() : NotFound();
    }

    [HttpDelete("DeleteItemInCart")]
    public async Task<ActionResult> DeleteItemInCart([FromBody]DeleteCartItemDto deleteDto)
    {
        var result = await _mediator.SendAsync(new DeleteItemInCartCommand(deleteDto.IdCartItem,deleteDto.UserId));
        return result ? NoContent() : NotFound();
    }
}