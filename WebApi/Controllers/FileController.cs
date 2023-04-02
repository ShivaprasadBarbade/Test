using CorporateClassifieds.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public IActionResult GetFile(Guid id)
        {
            try
            {
                var bytes = _fileService.GetFile(id);

                var memoryStream = new MemoryStream(bytes);

                return Ok(memoryStream);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile formFile)
        {
            try
            {
                _fileService.AddFile(formFile);

                return Ok("success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
