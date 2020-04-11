using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries;
using Application.Products.Queries.GetProductById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.RequestModel;

namespace RestoChaud.Controllers
{
    public class ProductController : BaseController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var result = await Mediator.Send(query).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody]UpdateProductRequest model)
        {
            await Mediator.Send(new UpdateProductCommand(model.ProductId, model.ProductName, model.CategoryId, model.QuantityPerUnit, model.UnitPrice, model.UnitsInStock));
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest model)
        {
            await Mediator.Send(new CreateProductCommand(model.ProductName, model.CategoryId, model.QuantityPerUnit, model.UnitPrice, model.UnitsInStock));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand(id)).ConfigureAwait(false);
            return NoContent();
        }
    }
}
