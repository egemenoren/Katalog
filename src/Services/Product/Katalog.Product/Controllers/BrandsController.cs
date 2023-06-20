using Katalog.Product.Repositories.Abstract;
using Katalog.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Katalog.Product.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BrandsController : ControllerBase
    {
        #region Constructor
        private readonly IBrandRepository _brandRepository;

        public BrandsController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        #endregion

        #region CRUD Operations
        #region Create
        [HttpPost("create")]
        [ProducesResponseType(typeof(Entities.Brand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<ResponseDto<Entities.Brand>>> CreateBrand([FromBody] Entities.Brand brand)
        {
            await _brandRepository.Create(brand);
            return CreatedAtRoute("GetBrand", new { id = brand.Id }, ResponseDto<Entities.Brand>.Success(brand,200));
        }
        #endregion

        #region Get All
        [HttpGet("getallbrands")]
        [ProducesResponseType(typeof(ResponseDto<IEnumerable<Entities.Brand>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseDto<IEnumerable<Entities.Brand>>>> GetBrands()
        {
            var brands = await _brandRepository.GetAll();
            return Ok(ResponseDto<IEnumerable<Entities.Brand>>.Success(brands,200));
        }
        #endregion
        
        #region Get By Id
        [HttpGet("{id:length(24)}", Name = "GetBrand")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResponseDto<Entities.Brand>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Brand>> GetBrand(string id)
        {
            var brand = await _brandRepository.GetById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(ResponseDto<Entities.Brand>.Success(brand,200));
        }
        #endregion

        #region Update
        [HttpPut("update")]
        [ProducesResponseType(typeof(ResponseDto<Entities.Brand>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBrand([FromBody] Entities.Brand brand)
        {
            try
            {
            await _brandRepository.Update(brand);
            return Ok(ResponseDto.Success(200));
                
            }
            catch (Exception ex)
            {
                return Ok(ResponseDto.Fail(ex.Message,500));
            }
        }
        #endregion

        #region Bulk Update
        [HttpPut("updatebulk")]
        [ProducesResponseType(typeof(Entities.Brand), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany([FromBody] List<Entities.Brand> brands)
        {
            var result = await _brandRepository.UpdateMany(brands);
            if (result)
                return Ok(ResponseDto.Success(200));
            return Ok(ResponseDto<Entities.Brand>.Fail("An unexpeced error occurred",500));
        }
        #endregion

        #region Delete
        [HttpDelete("delete")]
        [ProducesResponseType(typeof(ResponseDto<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBrandById(string id)
        {
            return Ok(ResponseDto<bool>.Success(await _brandRepository.Delete(id),200));
        }
        #endregion

        #region Bulk Delete
        [HttpDelete("deletebulk")]
        [ProducesResponseType(typeof(ResponseDto<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<string> ids)
        {
            return Ok(await _brandRepository.DeleteMany(ids));
        }
        #endregion
        #endregion
    }
}
