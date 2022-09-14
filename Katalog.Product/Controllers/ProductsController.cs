using Katalog.Product.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;

namespace Katalog.Product.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Constructor
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Crud_Actions

        [HttpGet("getallproducts")]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Product>>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Product>> GetProduct(string id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Entities.Product>> CreateProduct([FromBody] Entities.Product product)
        {
            await _productRepository.Create(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("update")]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Entities.Product product)
        {
            return Ok(await _productRepository.Update(product));
        }

        [HttpPut("updatebulk")]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany([FromBody] List<Entities.Product> products)
        {
            return Ok(await _productRepository.UpdateMany(products));
        }


        [HttpDelete("{id:length(24)}", Name = "delete")]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _productRepository.Delete(id));
        }

        [HttpDelete("{ids:length(24)}", Name = "deletebulk")]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<string> ids)
        {
            return Ok(await _productRepository.DeleteMany(ids));
        }

        #endregion
    }
}
