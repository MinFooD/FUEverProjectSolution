using DataAccessLayer.Entities;

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
    Task<IEnumerable<Pet>> GetPets();

    /// <summary>
    /// Adds a new pet into the pets table asynchronously.
    /// </summary>
    /// <param name="pet">The pet to be added</param>
    /// <returns>Returns the added pet object or null if unsuccessful</returns>
    Task<Pet?> AddPet(Pet pet);
}