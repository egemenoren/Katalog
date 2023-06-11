using Katalog.Photo.Dtos;
using Katalog.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Katalog.Photo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo,CancellationToken cancellationToken)
        {
            if(photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\photos", photo.FileName);
                using var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream, cancellationToken);
                var returnPath = "photos/" + photo.FileName;

                var photoDto = new PhotoDto { Url = returnPath};
                return Ok(ResponseDto<PhotoDto>.Success(photoDto, 200));

            }
            return Ok(ResponseDto<PhotoDto>.Fail("Photo is empty", 400));

        }
        public IActionResult PhotoDelete(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwrootphotos", photoUrl);
            if(!System.IO.File.Exists(path))
                return Ok(ResponseDto<PhotoDto>.Fail("Photo could not be found", 404));
            System.IO.File.Delete(path);
            return Ok(ResponseDto.Success(204));

        }
    }
}
