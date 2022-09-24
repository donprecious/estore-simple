using Microsoft.AspNetCore.Mvc;
using PassMerchantMiddleware.Application.Product.Commands;
using PassMerchantMiddleware.Application.Product.Query;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers;

public class ProductController : ApiControllerBase
{
    
    [HttpPost]
    [SwaggerOperation(Summary = "create a product")]
  public  async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand productCommand)
  {
      var result = await Mediator.Send(productCommand);
      return Ok(result);
  }

  [HttpGet]
  [SwaggerOperation(Summary = "Get all products")]
  public async Task<IActionResult> GetProducts([FromQuery] GetProductQuery productQuery)
  {
      var result = await Mediator.Send(productQuery);
      return Ok(result);
  }
  
}