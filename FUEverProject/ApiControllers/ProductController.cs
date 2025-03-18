using AutoMapper;
using BusinessLogicLayer.Dtos.ProductDtos;
using BusinessLogicLayer.ServiceContracts;
using FUEverProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FueverProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct(Guid? storeId)
        {
            var products = await _productService.GetAllProductAsync(storeId);
            return Ok(products);
        }

        [HttpPost]
        [Authorize(Roles = "StoreOwner")]
        public async Task<IActionResult> Create([FromBody] AddProductRequestDTO addProductRequestDTO)
        {
            var product = await _productService.CreateAsync(addProductRequestDTO);
			return Ok(product);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "StoreOwner")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductRequestDTO updateProductRequestDTO)
        {
            var product = await _productService.UpdateAsync(id, updateProductRequestDTO);
			return Ok(product);
		}

		[HttpDelete]
		[Route("{id:Guid}")]
		[Authorize(Roles = "StoreOwner")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			var deleteProductDomainModel = await _productService.DeleteAsync(id);
			if (deleteProductDomainModel == null)
			{
				return NotFound();
			}
			return Ok(deleteProductDomainModel);

		}
	}
}