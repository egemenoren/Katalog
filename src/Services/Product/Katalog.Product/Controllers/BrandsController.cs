using Katalog.Product.Repositories.Abstract;
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
        public async Task<ActionResult<Entities.Brand>> CreateBrand([FromBody] Entities.Brand brand)
        {
            await _brandRepository.Create(brand);
            return CreatedAtRoute("GetBrand", new { id = brand.Id }, brand);
        }
        #endregion

        #region Get All
        [HttpGet("getallbrands")]
        [ProducesResponseType(typeof(Entities.Brand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Brand>>> GetBrands()
        {
            var brands = await _brandRepository.GetAll();
            return Ok(brands);
        }
        #endregion
        
        #region Get By Id
        [HttpGet("{id:length(24)}", Name = "GetBrand")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Entities.Brand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Brand>> GetBrand(string id)
        {
            var brand = await _brandRepository.GetById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }
        #endregion

        #region Update
        [HttpPut("update")]
        [ProducesResponseType(typeof(Entities.Brand), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBrand([FromBody] Entities.Brand brand)
        {
            return Ok(await _brandRepository.Update(brand));
        }
        #endregion

        #region Bulk Update
        [HttpPut("updatebulk")]
        [ProducesResponseType(typeof(Entities.Brand), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany([FromBody] List<Entities.Brand> brands)
        {
            return Ok(await _brandRepository.UpdateMany(brands));
        }
        #endregion

        #region Delete
        [HttpDelete("delete")]
        [ProducesResponseType(typeof(Entities.Brand), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBrandById(string id)
        {
            return Ok(await _brandRepository.Delete(id));
        }
        #endregion

        #region Bulk Delete
        [HttpDelete("deletebulk")]
        [ProducesResponseType(typeof(Entities.Brand), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<string> ids)
        {
            return Ok(await _brandRepository.DeleteMany(ids));
        }
        #endregion
        #endregion
    }
}
