using Katalog.Product.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Katalog.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        #region Constructor
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion

        #region CRUD Operations
        #region Create
        [HttpPost("create")]
        [ProducesResponseType(typeof(Entities.Category), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Entities.Category>> CreateCategory([FromBody] Entities.Category category)
        {
            await _categoryRepository.Create(category);
            return CreatedAtRoute("GetCategory", new { id = category.Id }, category);
        }
        #endregion

        #region Get All
        [HttpGet("getallcategories")]
        [ProducesResponseType(typeof(Entities.Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Category>>> GetCategories()
        {
            var categories = await _categoryRepository.GetAll();
            return Ok(categories);
        }
        #endregion

        #region Get By Id
        [HttpGet("{id:length(24)}", Name = "GetCategory")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Entities.Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Category>> GetCategory(string id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        #endregion

        #region Update
        [HttpPut("update")]
        [ProducesResponseType(typeof(Entities.Category), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCategory([FromBody] Entities.Category category)
        {
            return Ok(await _categoryRepository.Update(category));
        }
        #endregion

        #region Bulk Update
        [HttpPut("updatebulk")]
        [ProducesResponseType(typeof(Entities.Category), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMany([FromBody] List<Entities.Category> categories)
        {
            return Ok(await _categoryRepository.UpdateMany(categories));
        }
        #endregion

        #region Delete
        [HttpDelete("delete")]
        [ProducesResponseType(typeof(Entities.Category), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCategoryById(string id)
        {
            return Ok(await _categoryRepository.Delete(id));
        }
        #endregion

        #region Bulk Delete
        [HttpDelete("deletebulk")]
        [ProducesResponseType(typeof(Entities.Category), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMany(List<string> ids)
        {
            return Ok(await _categoryRepository.DeleteMany(ids));
        }
        #endregion
        #endregion
    }
}
