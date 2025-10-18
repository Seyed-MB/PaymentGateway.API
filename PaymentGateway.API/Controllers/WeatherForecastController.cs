using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Application.Handlers;

namespace PaymentGateway.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PaymentGateway.Application.Models.CreateProductCommand command)
    {
        var id = await _mediator.Send(command);
        Console.WriteLine("Feature branch test log");
        return Ok(new { Message = "Product create successfully V2", ProductId = id });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }
}
