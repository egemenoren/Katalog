using AutoMapper;
using Katalog.Product.DTOs;
using Katalog.Product.Repositories.Abstract;
using Katalog.Shared;
using Microsoft.AspNetCore.Mvc;
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

        #endregion Constructor

        #region Crud_Actions

        #region Create

        [HttpPost("create")]
        [ProducesResponseType(typeof(DTOs.ProductDTO), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<DTOs.ProductDTO>> CreateProduct([FromBody] Entities.Product product)
        {
            await _productRepository.Create(product);
            ProductDTO entity = _mapper.Map<ProductDTO>(product);
            return Ok();
        }

        #endregion Create

        #region Get All

        [HttpGet("getallproducts")]
        [ProducesResponseType(typeof(DTOs.ProductDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Product>>> GetProducts()
        {
            var products = await _productRepository.GetAll();
            var listProductDto = _mapper.Map<List<ProductDTO>>(products);
            for (int i = 0; i < listProductDto.Count; i++)
            {
                listProductDto[i].Category = await _categoryRepository.GetById(listProductDto[i].Category.Id);
                listProductDto[i].Brand = await _brandRepository.GetById(listProductDto[i].Brand.Id);
            }
            return Ok(ResponseDto<List<ProductDTO>>.Success(listProductDto, 1));
        }

        #endregion Get All

        #region Get By Id

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(DTOs.ProductDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Product>> GetProduct(string id)
        {
            var product = await _productRepository.GetById(id);
            var productDto = _mapper.Map<ProductDTO>(product);
            if (product == null)
            {
                return NotFound();
            }
            productDto.Category = await _categoryRepository.GetById(product.CategoryId);
            productDto.Brand = await _brandRepository.GetById(product.BrandId);
            return Ok(ResponseDto<ProductDTO>.Success(productDto, 1));
        }

        #endregion Get By Id

        #region Update

        [HttpPut("update")]
        [ProducesResponseType(typeof(DTOs.ProductDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] DTOs.ProductDTO product)
        {
            Entities.Product entity = _mapper.Map<Entities.Product>(product);
            return Ok(await _productRepository.Update(entity));
        }

        #endregion Update

        #region Bulk Update

        [HttpPut("updatebulk")]
        [ProducesResponseType(typeof(DTOs.ProductDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany([FromBody] List<DTOs.ProductDTO> products)
        {
            List<Entities.Product> entities = _mapper.Map<List<Entities.Product>>(products);
            return Ok(await _productRepository.UpdateMany(entities));
        }

        #endregion Bulk Update

        #region Delete

        [HttpDelete("delete")]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _productRepository.Delete(id));
        }

        #endregion Delete

        #region Bulk Delete

        [HttpDelete("deletebulk")]
        [ProducesResponseType(typeof(Entities.Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<string> ids)
        {
            return Ok(await _productRepository.DeleteMany(ids));
        }

        #endregion Bulk Delete

        #endregion Crud_Actions
    }
}