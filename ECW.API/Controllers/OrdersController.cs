using System.Security.Claims;
using ECW.ApplicationCore.DTOs.Order;
using ECW.ApplicationCore.Features.Orders;
using ECW.ApplicationCore.Interfaces;
using ECW.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECW.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class OrdersController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IProductService _productService;

    public OrdersController(IMediator mediator, IProductService productService)
    {
        _mediator = mediator;
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string buyerId)
    {
        var orders = await _mediator.Send(new GetOrdersCommand(buyerId));

        return Ok(orders);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateOrderRequest request)
    {
        var itemNotExist = await _productService
            .CheckIfNotExistAsync(request.OrderItems.Select(oi => oi.ProductId).ToArray());
        
        if (itemNotExist != null)
            return BadRequest($"Product with Id {itemNotExist} does't exist.");

        var order = await _mediator.Send(new CreateOrderCommand(request));

        return Ok(order);
    }
}