using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using TaskAPI.DTOs.Response;
using TaskAPI.Models;
using TaskAPI.Unit_of_Work;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var allCategories = _unitOfWork.Categories.Get(includes: [e=>e.Products]);
            
            return Ok(allCategories.Adapt<IEnumerable<CategoryResponse>>());
        }
        [HttpGet("{id}")]
        public IActionResult Getone([FromRoute] int id)
        {
            var allCategories = _unitOfWork.Categories.GetOne(e=>e.Id == id);
            if (allCategories is not null)
            return Ok(allCategories.Adapt<CategoryResponse>());
            else return NotFound();
        }
    }
}
