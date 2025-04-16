using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.DTOs;
using TaskAPI.Models;
using TaskAPI.Unit_of_Work;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unintOfWork;
        public ProductController(IUnitOfWork unintOfWork )
        {
            _unintOfWork = unintOfWork;
        }

        [HttpGet("")]
       public IActionResult GetAll([FromQuery] ProductSearch productSearch)
        {
            var allProducts = _unintOfWork.Products.Get(includes: [e=>e.ProductImages , e=>e.Category]);

            if (productSearch.CategoryName is not null)
            {
                allProducts = allProducts.Where(e => e.Category.Name.Contains(productSearch.CategoryName, StringComparison.OrdinalIgnoreCase));
            }

            if (productSearch.Model is not null)
            {
                allProducts = allProducts.Where(e => e.Model.Contains(productSearch.Model, StringComparison.OrdinalIgnoreCase));
            }

            if (productSearch.MaxPrice.HasValue && productSearch.MinPrice is null)
            {
                allProducts = allProducts.Where(e => e.Price * (1 - e.Discount) <= (productSearch.MaxPrice));
            }

            if (productSearch.MinPrice.HasValue && productSearch.MaxPrice is null)
            {
                allProducts = allProducts.Where(e => e.Price * (1 - e.Discount) >= (productSearch.MinPrice));
            }

            if (productSearch.MaxPrice.HasValue && productSearch.MinPrice.HasValue)
            {
                allProducts = allProducts.Where(e => e.Price <= productSearch.MaxPrice && e.Price >= productSearch.MinPrice);
            }

            return Ok(allProducts.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute]int id)
        {
            var allProducts = _unintOfWork.Products.Get(e=>e.Id==id,includes: [e => e.ProductImages]);
            return Ok(allProducts);
        }

      

    }
}
