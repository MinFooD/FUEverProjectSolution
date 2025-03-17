using BusinessLogicLayer.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace FueverProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStore(Guid? id)
        {
            var stores = await _storeService.GetStoreAsync(id);
            return Ok(stores);
        }
    }
}