using BusinessLogicLayer.Dtos.PetDtos;

namespace BusinessLogicLayer.ServiceContracts;

public interface IPetsService
{
    /// <summary>
    /// Retrieves the list of pets from the pets repository
    /// </summary>
    /// <returns>Returns list of PetResponse objects</returns>
    Task<IEnumerable<PetResponse?>> GetPets();
}