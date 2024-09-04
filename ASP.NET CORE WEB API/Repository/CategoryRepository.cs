using ASP.NET_CORE_WEB_API.Data;
using ASP.NET_CORE_WEB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CORE_WEB_API.Repository
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            //creates a LINQ query based on a raw SQL query
            return await _context.Categories.FromSqlRaw("SELECT * FROM Categories").ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories.FromSqlRaw("SELECT * FROM Categories WHERE Id = {0}", id).FirstOrDefaultAsync();
        }
    }
}
