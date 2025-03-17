using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

    public async Task<Pet?> GetPetByCondition(Expression<Func<Pet, bool>> conditionExpression)
    {
        return await _dbContext.Pets.FirstOrDefaultAsync(conditionExpression);
    }

    public async Task<Pet?> AddPet(Pet pet)
    {
        _dbContext.Pets.Add(pet);
        await _dbContext.SaveChangesAsync();
        return pet;
    }

    public async Task<Pet?> UpdatePet(Pet pet)
    {
        Pet? existingPet = await _dbContext.Pets.FirstOrDefaultAsync(temp => temp.PetID == pet.PetID);

        if (existingPet == null)
            return null;

        existingPet.PetName = pet.PetName;
        existingPet.Breed = pet.Breed;
        existingPet.Age = pet.Age;
        existingPet.SpecialPathology = pet.SpecialPathology;
        existingPet.Weight = pet.Weight;
        existingPet.Diet = pet.Diet;
        existingPet.Gender = pet.Gender;
        existingPet.Habit = pet.Habit;
        existingPet.OtherRequest = pet.OtherRequest;
        existingPet.HealthDetail = pet.HealthDetail;
        existingPet.Image = pet.Image;

        await _dbContext.SaveChangesAsync();

        return existingPet;
    }
}