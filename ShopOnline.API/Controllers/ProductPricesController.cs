using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Products;
using ShopOnline.API.Models;

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPricesController : ControllerBase
    {
        private readonly ShopOnlineContext _context;

        public ProductPricesController(ShopOnlineContext context)
        {
            _context = context;
        }

        // GET: api/ProductPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductPrice>>> GetProductPrices()
        {
            return await _context.ProductPrices.ToListAsync();
        }

        // GET: api/ProductPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductPrice>> GetProductPrice(int id)
        {
            var productPrice = await _context.ProductPrices.FindAsync(id);

            if (productPrice == null)
            {
                return NotFound();
            }

            return productPrice;
        }

        // PUT: api/ProductPrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductPrice(int id, ProductPrice productPrice)
        {
            
            if (id != productPrice.Id)
            {
                return BadRequest();
            }
            //Calculate SalePercent
            productPrice.SalePercent = Decimal.Round((productPrice.OldPrice-productPrice.CurrentPrice)/productPrice.OldPrice*100);
            _context.Entry(productPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPriceExists(id))
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

        // POST: api/ProductPrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductPrice>> PostProductPrice(ProductPrice productPrice)
        {
            //Calculate SalePercent
            productPrice.SalePercent = Decimal.Round((productPrice.OldPrice-productPrice.CurrentPrice)/productPrice.OldPrice*100);
            //add productPrice to context
            _context.ProductPrices.Add(productPrice);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductPriceExists(productPrice.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductPrice", new { id = productPrice.Id }, productPrice);
        }

        // DELETE: api/ProductPrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductPrice(int id)
        {
            var productPrice = await _context.ProductPrices.FindAsync(id);
            if (productPrice == null)
            {
                return NotFound();
            }

            _context.ProductPrices.Remove(productPrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductPriceExists(int id)
        {
            return _context.ProductPrices.Any(e => e.Id == id);
        }
    }
}
