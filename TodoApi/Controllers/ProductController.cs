using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Context;
using ProductApi.Models;

namespace TodoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
          return await _context.Product.ToListAsync();
        }

        // GET: api/TodoItems/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetTodoItem(Guid id, Product product)
        {
            if (product == null) return NotFound();
            return await _context.Product.FindAsync(id);
        }

        // PUT: api/TodoItems/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(Guid id, Product product)
        {
            var prod = await _context.Product.FindAsync(id);
            if (prod == null) return NotFound();

            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Description = product.Description;

            _context.Product.Update(prod);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Successfully Edited" });
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<Product>> PostTodoItem(Product product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            var prod = await _context.Product.FindAsync(id);
            if (prod == null) return NotFound();

            _context.Product.Remove(prod);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Successfully Deleted" });
        }

    }
}

