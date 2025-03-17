using AutoMapper;
using BusinessLogicLayer.Dtos.ProductDtos;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.RepositoryContracts;

namespace BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetAllProductAsync(Guid? storeId)
        {
            var products = await _productRepository.GetAllProductAsync(storeId);
            var productsDTO = _mapper.Map<List<ProductDTO>>(products);
            return productsDTO;
        }
    }
}