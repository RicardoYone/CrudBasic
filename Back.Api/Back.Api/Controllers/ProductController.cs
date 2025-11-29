using Back.Api.Application.Services.Product.Commands.Create;
using Back.Api.Application.Services.Product.Commands.Delete;
using Back.Api.Application.Services.Product.Commands.Update;
using Back.Api.Application.Services.Product.Queries.GetProduct;
using Back.Api.Application.Services.Product.Queries.GetProductById;
using Back.Api.Domain.Entities;
using Back.Api.Middleware;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct()
        {
            var response = new BaseResponseModel<List<ProductEntity>>();
            GetProductQuery request = new GetProductQuery();
            response.Data = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = new BaseResponseModel<ProductEntity>();
            GetProductByIdQuery request = new GetProductByIdQuery();
            request.Id = id;
            response.Data = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var response = new BaseResponseModel<bool>();
            //command.UserAudit = HttpContext.Request.Headers["UserAudit"];
            response.Data = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            var response = new BaseResponseModel<bool>();
            //command.UserAudit = HttpContext.Request.Headers["UserAudit"];
            response.Data = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command)
        {
            var response = new BaseResponseModel<bool>();
            //command.UserAudit = HttpContext.Request.Headers["UserAudit"];
            response.Data = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
