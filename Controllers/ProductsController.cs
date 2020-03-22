using Crow.Shop.Models;
using Crow.Shop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crow.Shop.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductItem>>> GetProducts()
        {
            return await this.productService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await this.productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                await this.productService.Update(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.productService.CheckIfExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //[Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await this.productService.Create(product);
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            if (!this.productService.CheckIfExists(id))
            {
                return NotFound();
            }

            await this.productService.Delete(id);

            return Ok();
        }
    }
}
