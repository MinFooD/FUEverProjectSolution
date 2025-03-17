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

    /// <summary>
    /// Updates the exsting pet based on the PetID
    /// </summary>
    /// <param name="petUpdateRequest">Pet data to update</param>
    /// <returns>Returns pet object after successful updation; otherwise null</returns>
    Task<PetResponse?> UpdatePet(PetUpdateRequest petUpdateRequest);

    /// <summary>
    /// Deletes an exsting pet based on given pet ID
    /// </summary>
    /// <param name="petID">PetID to search and delete</param>
    /// <returns>Returns true if the deletion is successful; otherwise false</returns>
    Task<bool> DeletePet(Guid petID);
}