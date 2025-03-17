using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FueverDbContext _context;

        public CategoryRepository(FueverDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetCategoryAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
    }
}