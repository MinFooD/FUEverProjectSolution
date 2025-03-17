using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly FueverDbContext _context;

        public ProductRepository(FueverDbContext context)
        {
            _context = context;
        }

		public async Task<Product> CreateAsync(Product product)
		{
			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();
			return product;
		}

		public async Task<List<Product>> GetAllProductAsync(Guid? storeId)
        {
            var products = _context.Products.AsQueryable();
            if (storeId != null)
            {
                products = products.Where(p => p.StoreID == storeId);
            }
            return await products.ToListAsync();
        }
    }
}