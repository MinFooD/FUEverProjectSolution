using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly FueverDbContext _context;
        public StoreRepository(FueverDbContext context)
        {
            _context = context;
        }
        public async Task<List<Store>> GetStoreAsync(Guid? ownerId)
        {
            var stores = _context.Stores.AsQueryable();
            if (ownerId != null)
            {
                stores = stores.Where(s => s.OwnerID == ownerId);
            }
            return await stores.ToListAsync();
        }
    }
}