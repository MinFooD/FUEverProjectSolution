using BusinessLogicLayer.Dtos.PetDtos;

namespace BusinessLogicLayer.ServiceContracts;

public interface IPetsService
{
    /// <summary>
    /// Retrieves the list of pets from the pets repository
    /// </summary>
    /// <returns>Returns list of PetResponse objects</returns>
    Task<IEnumerable<PetResponse?>> GetPets();

    /// <summary>
    /// Adds (inserts) pet into the table using pets repository
    /// </summary>
    /// <param name="petAddRequest">Pet to insert</param>
    /// <returns>Pet after inserting or null if unsuccessful</returns>
    Task<PetResponse?> AddPet(PetAddRequest petAddRequest);
}