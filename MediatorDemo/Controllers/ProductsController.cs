using MediatorDemo.Commands;
using MediatorDemo.Models;
using MediatorDemo.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MediatorDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _mediator.Send(new GetProductsQuery()));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var res = await _mediator.Send(new GetProductByIdQuery(id));
            if (res == default)
            {
                return Ok("Product not found!");
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var res = await _mediator.Send(new AddProductCommand(product));
            return CreatedAtRoute("GetProductById", new {Id = product.Id}, res);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var res = await _mediator.Send(new DeleteProductByIdCommand(id));
            if (res == default)
            {
                return Ok("Product not found!");
            }
            else
            {
                return CreatedAtRoute("GetProductById", new { Id = id }, res);
            }
        }
    }
}
