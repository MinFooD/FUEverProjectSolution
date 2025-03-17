using AutoMapper;
using BusinessLogicLayer.Dtos.StoreDtos;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.RepositoryContracts;

namespace BusinessLogicLayer.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;

    public StoreService(IStoreRepository storeRepository, IMapper mapper)
    {
        _storeRepository = storeRepository;
        _mapper = mapper;
    }
    public async Task<List<StoreDTO>> GetStoreAsync(Guid? id)
    {
        var stores = await _storeRepository.GetStoreAsync(id);
        var storesDTO = _mapper.Map<List<StoreDTO>>(stores);
        return storesDTO;
    }
}