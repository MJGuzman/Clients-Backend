using ClientMaster.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientMaster.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly IProvinceService _provinceService;

        public ProvincesController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        // GET: api/<ProvincesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _provinceService.GetAllAsync();

            return Ok(result);
        }

        // GET api/<ProvincesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _provinceService.GetByIdAsync(id);

            return Ok(result);
        }


    }
}
