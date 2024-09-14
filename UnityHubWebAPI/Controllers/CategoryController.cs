using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnityHubWebAPI.IServices;

namespace UnityHubWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryServices _services;

        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }
        [HttpGet]
        [Route("CategoryList")]
        public async Task<IActionResult> CategoryList()
        {
            var categorylist = await _services.GetAllAsync();
            return Ok(categorylist);
        }
    }
}
