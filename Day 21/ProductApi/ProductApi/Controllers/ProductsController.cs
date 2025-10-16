using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service) 
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetById(id);
            if (product == null) 
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _service.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updatedProduct)
        {
            var updated = _service.Update(id, updatedProduct);
            if (!updated) 
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted) 
                return NotFound(); 
            return NoContent();
        }
    }
}
