using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

public class PetsRepository(FueverDbContext dbContext) : IPetsRepository
{
    private readonly FueverDbContext _dbContext = dbContext;

    public async Task<IEnumerable<Pet>> GetPets()
    {
        return await _dbContext.Pets
            .Include(p => p.PetOwner)
            .Include(p => p.Bookings)
            .ToListAsync();
    }
}