using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDunnhumbyAssessment.Entities;

namespace WebApiDunnhumbyAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {   
        private readonly ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

    }
}
