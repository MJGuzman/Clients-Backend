using ClientMaster.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientMaster.Api.Controllers
{
    [Route("api/provinces/{provinceId:int}/municipalities/{municipalityId:int}/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private readonly ISectorService _sectorService;

        public SectorsController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }
        // GET: api/<ProvincesController>
        [HttpGet]
        public async Task<IActionResult> Get(int provinceId, int municipalityId)
        {
            var result = await _sectorService.GetAllAsync(provinceId, municipalityId);

            return Ok(result);
        }

        // GET api/<ProvincesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int provinceId, int municipalityId, int id)
        {
            var result = await _sectorService.GetByIdAsync(provinceId, municipalityId, id);

            return Ok(result);
        }


    }
}
