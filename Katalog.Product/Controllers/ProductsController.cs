using AutoMapper;
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository, IBrandRepository brandRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }
        #endregion

        #region Crud_Actions

        #region Create
        [HttpPost("create")]
        [ProducesResponseType(typeof(DTOs.ProductDTO), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<DTOs.ProductDTO>> CreateProduct([FromBody] DTOs.ProductDTO product)
        {
            Entities.Product entity = _mapper.Map<Entities.Product>(product);
            var category = _categoryRepository.GetById(product.CategoryId).Result;
            var brand = _brandRepository.GetById(product.BrandId).Result;
            entity.CreateTime = DateTime.Now;
            entity.Category = category.Data;
            entity.Brand = brand.Data;
            await _productRepository.Create(entity);
            return CreatedAtRoute("GetProduct", new { id = entity.Id }, entity);
        }
        #endregion

        #region Get All
        [HttpGet("getallproducts")]
        [ProducesResponseType(typeof(DTOs.ProductDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Product>>> GetProducts()
        {
            var products = await _productRepository.GetAll();
            for (int i = 0; i < products.Data.Count; i++)
            {
                var brand = _brandRepository.GetById(products.Data[i].BrandId).Result;
                var category = _categoryRepository.GetById(products.Data[i].CategoryId).Result;
                if (brand !=null)              
                    products.Data[i].Brand = brand.Data;
                if (category != null)
                    products.Data[i].Category = category.Data;
                else
                    continue;
            }
            return Ok(products.Data);
        } 
        #endregion

        #region Get By Id
        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(DTOs.ProductDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Product>> GetProduct(string id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            //???? are those true?
            product.Data.Category = _categoryRepository.GetById(product.Data.CategoryId).Result.Data;
            product.Data.Brand = _brandRepository.GetById(product.Data.BrandId).Result.Data;
            return Ok(product);
        } 
        #endregion

        #region Update
        [HttpPut("update")]
        [ProducesResponseType(typeof(DTOs.ProductDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] DTOs.ProductDTO product)
        {
            Entities.Product entity = _mapper.Map<Entities.Product>(product);
            return Ok(await _productRepository.Update(entity));
        } 
        #endregion

        #region Bulk Update
        [HttpPut("updatebulk")]
        [ProducesResponseType(typeof(DTOs.ProductDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany([FromBody] List<DTOs.ProductDTO> products)
        {
            List<Entities.Product> entities = _mapper.Map<List<Entities.Product>>(products);
            return Ok(await _productRepository.UpdateMany(entities));
        }
        #endregion


        #region Delete
        [HttpDelete("delete")]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _productRepository.Delete(id));
        }
        #endregion

        #region Bulk Delete
        [HttpDelete("deletebulk")]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<string> ids)
        {
            return Ok(await _productRepository.DeleteMany(ids));
        } 
        #endregion

        #endregion
    }
}
