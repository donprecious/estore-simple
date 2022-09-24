using Microsoft.AspNetCore.Mvc;
using PassMerchantMiddleware.Application.Overview.Query;
using PassMerchantMiddleware.Application.Product.Commands;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers;

public class Overview : ApiControllerBase
{
    [HttpGet]
    [SwaggerOperation(Summary = "Get overview")]
    public async Task<IActionResult> GetOverview([FromQuery] GetOverviewQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}