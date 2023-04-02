//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using CorporateClassifieds.Services.Interfaces;
//using AutoMapper;
//using System.ComponentModel;
//using CorporateClassifieds.Repository.Dapper.DataModels;

//namespace WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CategoryController : ControllerBase
//    {
//        private readonly ICategoryService _cateogoryService;
//        private readonly IMapper _mapper;
//        public CategoryController(ICategoryService categoryService,IMapper mapper) 
//        {
//            _cateogoryService= categoryService;
//            _mapper = mapper;
//        }
//        [HttpPost]
//        public IActionResult CreateCategory(Category newCategory, CategoryAttribute newAttribute)
//        {
//            try
//            {
//                _cateogoryService.CreateCategory(newCategory,newAttribute);
//                return Ok(newCategory);

//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500,ex.Message);
//            }

//        }
//    }
//}
