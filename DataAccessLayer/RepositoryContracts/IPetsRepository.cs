using DataAccessLayer.Entities;
using System.Linq.Expressions;

namespace DataAccessLayer.RepositoryContracts;

/// <summary>
/// Represents a repository for managing 'pet' table
/// </summary>
public interface IPetsRepository
{
    /// <summary>
    /// Retrieves all pets asynchronously.
    /// </summary>
    /// <returns>Returns all pets from the table</returns>
    Task<IEnumerable<Pet>> GetPets(Guid userId);

    /// <summary>
    /// Retrieves a single pet based on the specified condition asynchronously.
    /// </summary>
    /// <param name="conditionExpression">The condition to filter the pet</param>
    /// <returns>Returns a single pet or null if not found\</returns>
    Task<Pet?> GetPetByCondition(Expression<Func<Pet, bool>> conditionExpression);

    /// <summary>
    /// Adds a new pet into the pets table asynchronously.
    /// </summary>
    /// <param name="pet">The pet to be added</param>
    /// <returns>Returns the added pet object or null if unsuccessful</returns>
    Task<Pet?> AddPet(Pet pet);

    /// <summary>
    /// Updates an existing pet asynchronously.
    /// </summary>
    /// <param name="pet">The pet to be updated</param>
    /// <returns>Returns the updated pet or null if not found</returns>
    Task<Pet?> UpdatePet(Pet pet);

    /// <summary>
    /// Deletes the pet asynchronously.
    /// </summary>
    /// <param name="petID">The pet ID to be deleted</param>
    /// <returns>Returns true if the deletion is successful, false otherwise.</returns>
    Task<bool> DeletePet(Guid petID);
}