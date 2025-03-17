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
}