using AlonBuyumMoDEx.Server.DAL;
using AlonBuyumMoDEx.Server.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlonBuyumMoDEx.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ShoppingContext _shoppingContext;

        public CategoriesController(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }
        // GET: api/GetAllCategories
        [HttpGet, Route("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _shoppingContext.Categories.ToListAsync();
            return Ok(categories);
        }

        // GET: api/GetCategoryById/5
        [HttpGet, Route("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _shoppingContext.Categories.FindAsync(id);
            if (category == null) return NotFound("Category not found");
            return Ok(category);
        }

        // POST: api/AddCategory
        [HttpPost, Route("AddCategory")]
        public async  Task<IActionResult> AddCategory([FromBody]Category category)
        {
            if (category == null) return BadRequest("Category is null");

            var dbCategory =  _shoppingContext.Categories.Add(category);
            var saved = await _shoppingContext.SaveChangesAsync();

            if (saved < 0) return StatusCode(500, "Failed to save Category");
            return Ok(dbCategory.Entity);
        }
    }
}
