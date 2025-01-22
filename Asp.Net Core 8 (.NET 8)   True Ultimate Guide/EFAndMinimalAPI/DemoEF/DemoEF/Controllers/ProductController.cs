using DemoEF.Entities;
using DemoNop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoEF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ClassicModelsDBContext _context;

        public ProductController(ClassicModelsDBContext context)
        {
            _context = context;
        }
        [HttpGet("ProductsEagerLoading")]
        public async Task<ObjectResult> ProductsEagerLoading()
        {
            var products = await _context.Products.Where(t => t.ProductCode == "S10_1678")
            .Include(a => a.ProductLines).ToListAsync();

            return Ok(products);
        }
    }
}
