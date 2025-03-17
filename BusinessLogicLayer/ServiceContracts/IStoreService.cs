using BusinessLogicLayer.Dtos.StoreDtos;

namespace BusinessLogicLayer.ServiceContracts;

public interface IStoreService
{
    Task<List<StoreDTO>> GetStoreAsync(Guid? id);
}