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

		public async Task<Product?> DeleteAsync(Guid id)
		{
			var existingProduct = await _context.Products.Include("Category").FirstOrDefaultAsync(x => x.ProductID.Equals(id));
			if (existingProduct == null)
			{
				return null;
			}
			_context.Products.Remove(existingProduct);
			await _context.SaveChangesAsync();
			return existingProduct;
		}

		public async Task<List<Product>> GetAllProductAsync(Guid? storeId)
        {
            var products = _context.Products.Include("Category").AsQueryable();
            if (storeId != null)
            {
                products = products.Where(p => p.StoreID == storeId);
            }
            return await products.ToListAsync();
        }

		public async Task<Product?> UpdateAsync(Guid id, Product product)
        {
            var existingProduct = _context.Products.FirstOrDefault(x => x.ProductID == id);
			if (existingProduct == null)
			{
                return null;
			}
            existingProduct.ProductName = product.ProductName;
            existingProduct.Description = product.Description;
			existingProduct.ManufacturingDate = product.ManufacturingDate;
            existingProduct.ExpirationDate = product.ExpirationDate;
			existingProduct.StockQuantity = product.StockQuantity;
			existingProduct.Size = product.Size;
			existingProduct.Image = product.Image;
			existingProduct.StoreID = product.StoreID;
			existingProduct.CategoryID = product.CategoryID;
			await _context.SaveChangesAsync();
            return existingProduct;
		}
    }
}