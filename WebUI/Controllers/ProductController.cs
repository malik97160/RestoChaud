using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace RestoChaud.Controllers
{
    public class ProductController : BaseController
    {
        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var result = await Mediator.Send(query).ConfigureAwait(false);
            return Ok(result);

        }
    }
}
