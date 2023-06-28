using Katalog.Address.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Katalog.Address.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly WriteDatasToDb _writeDatasToDb;
        public AddressController(WriteDatasToDb writeDatasToDb)
        {
            _writeDatasToDb = writeDatasToDb;
        }
        [HttpGet]
        public async Task<IActionResult> WriteDatasToDb()
        {
            await _writeDatasToDb.GetDatas();
            return Ok();
        }
    }
}
