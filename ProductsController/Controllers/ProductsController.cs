using Microsoft.AspNetCore.Mvc;
using ProductsController.Models;

namespace ProductsController.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> products = new()
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 25000
            },
            new Product
            {
                Id = 2,
                Name = "Mouse",
                Price = 500
            },
            new Product
            {
                Id = 3,
                Name = "Keyboard",
                Price = 1000
            }
        };

        private static int nextId = 4;


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           var product = products.FirstOrDefault(c=>c.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product) {
            product.Id = nextId++;

            products.Add(product);

            return CreatedAtAction(
                nameof(GetById),
                new { id = product.Id },
                product);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateName(int id, Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return BadRequest(new
                {
                    message = "Name is required."
                });
            }

            var existingProduct = products.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;

            return Ok(existingProduct);
        }
    }
}