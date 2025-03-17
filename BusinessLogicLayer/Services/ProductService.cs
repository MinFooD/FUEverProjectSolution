using AutoMapper;
using BusinessLogicLayer.Dtos.ProductDtos;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
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

		public async Task<AddProductRequestDTO> CreateAsync(AddProductRequestDTO addProductRequestDTO)
		{
			var product = _mapper.Map<Product>(addProductRequestDTO);
            product = await _productRepository.CreateAsync(product);
            return _mapper.Map<AddProductRequestDTO>(product);
		}

		public async Task<ProductDTO?> DeleteAsync(Guid id)
		{
			var product = await _productRepository.DeleteAsync(id);
			return _mapper.Map<ProductDTO>(product);
		}

		public async Task<List<ProductDTO>> GetAllProductAsync(Guid? storeId)
        {
            var products = await _productRepository.GetAllProductAsync(storeId);
            var productsDTO = _mapper.Map<List<ProductDTO>>(products);
            return productsDTO;
        }

		public async Task<UpdateProductRequestDTO> UpdateAsync(Guid id, UpdateProductRequestDTO updateProductRequestDTO)
		{
			var product = _mapper.Map<Product>(updateProductRequestDTO);
			product = await _productRepository.UpdateAsync(id, product);
			return _mapper.Map<UpdateProductRequestDTO>(product);
		}
	}
}