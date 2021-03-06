﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Products;
using Models.Infrastructure;
using ShopOnline.API.Models;
using ShopOnline.API.Models.Helpers;
using ShopOnline.API.Services.ProductService;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopOnlineContext _context;
        private readonly IProductService _productService;
        public ProductsController(ShopOnlineContext context,
        IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts([FromQuery] ProductParameters productParameters)
        {

            var products = _productService.GetProducts(productParameters);
            //products.OrderBy("Id descending");
            var metadata = new
            {
                products.TotalCount,
                products.PageSize,
                products.CurrentPage,
                products.TotalPages,
                products.HasNext,
                products.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
            //Cho phép Client read X-Pagination in Headers
            Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");
            
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.Include(x => x.ProductPrice)
                                    .Include(x => x.ProductBrand)
                                    .Include(x => x.ProductType)
                                    .Include(x => x.ProductImages)
                                    .AsSplitQuery()
                                    .Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            try
            {
                // update product
                _productService.UpdateProduct(id, product);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
