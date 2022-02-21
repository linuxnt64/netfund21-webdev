using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Models;
using WebApi.Models.Entitites;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SqlContext _context;

        public ProductsController(SqlContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductEntity>> GetProductEntity(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);

            if (productEntity == null)
            {
                return NotFound();
            }

            return productEntity;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductEntity(int id, ProductEntity productEntity)
        {
            if (id != productEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(productEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductEntityExists(id))
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


        [HttpPost]
        public async Task<ActionResult<ProductEntity>> PostProductEntity(ProductCreateModel model)
        {
            if (await _context.Products.AnyAsync(x => x.Name == model.Name))
                return BadRequest();


            var productEntity = new ProductEntity
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };

            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductEntity", new { id = productEntity.Id }, productEntity);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductEntity(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductEntityExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
