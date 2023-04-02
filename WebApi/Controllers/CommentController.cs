using Microsoft.AspNetCore.Mvc;
using CorporateClassifieds.Models.CoreModels;
using CorporateClassifieds.Services.Interfaces;
namespace WebApi.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            this._service = service;
        }
        [HttpGet]
        public IActionResult GetAllComments()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment) 
        {
            _service.AddComment(comment);
            return View();
        }
    }
}
