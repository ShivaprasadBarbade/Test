using CorporateClassifieds.Models.Enums;
using CorporateClassifieds.Models.ViewModels;
using CorporateClassifieds.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassifiedController : ControllerBase
    {
        private readonly ClassifiedService _classifiedServices;

        public ClassifiedController(ClassifiedService classifiedServices)
        {
            _classifiedServices = classifiedServices;
        }

        [HttpPost]
        public IActionResult AddClassified(ClassifiedFormView classifiedView)
        {
            try
            {
                _classifiedServices.AddClassified(classifiedView);
                return Ok("success");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
        [HttpPost("Attachments")]
        public IActionResult AddAttachments([FromForm]List<IFormFile> attachments,Guid classifiedId)
        {
            try
            {
                _classifiedServices.AddAttachments(attachments,classifiedId);

                return Ok("success");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateClassified(ClassifiedFormView classifiedView)
        {
            try
            {
                _classifiedServices.UpdateClassified(classifiedView);

                return Ok("success");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public IActionResult DeleteAttachment(Guid classifiedId,short removedBy)
        {
            try
            {
                _classifiedServices.DeleteClassified(classifiedId, removedBy);
                    return Ok("success");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetClassified(Guid id)
        {
            try
            {
                return Ok(_classifiedServices.GetClassified(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Attachments")]
        public IActionResult GetAttachments(Guid classifiedId)
        {
            try
            {
                return Ok(_classifiedServices.GetAttachments(classifiedId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ClassifiedCards")]
        public IActionResult GetClassifiedCards(short? type, Guid? categoryId, string? location)
        {
            try
            {
                return Ok(_classifiedServices.GetClassifiedCards(type,categoryId,location));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
