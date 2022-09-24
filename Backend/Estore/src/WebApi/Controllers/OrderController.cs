using Microsoft.AspNetCore.Mvc;
using PassMerchantMiddleware.Application.Order.Command;
using PassMerchantMiddleware.Application.Order.Models;
using PassMerchantMiddleware.Application.Order.Query;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers;

public class OrderController : ApiControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create order")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand orderCommand)
    {
        var result = await Mediator.Send(orderCommand);
        return Ok(result);
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all orders")]
    public async Task<IActionResult> GetOrders([FromQuery] GetOrderQuery orderQuery)
    {
        var result = await Mediator.Send(orderQuery);
        return Ok(result);
    }
}