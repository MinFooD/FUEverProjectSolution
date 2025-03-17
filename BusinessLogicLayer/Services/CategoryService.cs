using AutoMapper;
using BusinessLogicLayer.Dtos.CategoryDtos;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.RepositoryContracts;

namespace BusinessLogicLayer.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<CategoryDTO>> GetCategoryAsync()
    {
        var categories = await _categoryRepository.GetCategoryAsync();
        var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories);
        return categoriesDTO;
    }
}