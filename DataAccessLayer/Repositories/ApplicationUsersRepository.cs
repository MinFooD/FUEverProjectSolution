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

    public async Task<ApplicationUser?> UpdateApplicationUsers(ApplicationUser application)
    {
        ApplicationUser? applicationUsers = await GetPetOwnerByIdAsync(application.Id);

        if (applicationUsers == null)
            return null;

        applicationUsers.UserName = application.UserName;
        applicationUsers.Email = application.Email;
        applicationUsers.PhoneNumber = application.PhoneNumber;
        applicationUsers.ProfileImage = application.ProfileImage;
        applicationUsers.DateOfBirth = application.DateOfBirth;
        applicationUsers.Address = application.Address;
        

        await _context.SaveChangesAsync();

        return applicationUsers;
    }
}
