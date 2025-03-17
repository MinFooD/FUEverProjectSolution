using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

public class ApplicationUsersRepository(FueverDbContext context) : IApplicationUsersRepository
{
    private readonly FueverDbContext _context = context;

    public async Task<ApplicationUser?> GetPetOwnerByIdAsync(Guid id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}
