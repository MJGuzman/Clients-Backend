using ClientMaster.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientMaster.Api.Controllers
{
    [Route("api/provinces/{provinceId:int}/[controller]")]
    [ApiController]
    public class MunicipalitiesController : ControllerBase
    {
        private readonly IMunicipalityService _municipalityService;

        public MunicipalitiesController(IMunicipalityService municipalityService)
        {
            _municipalityService = municipalityService;
        }
        // GET: api/<ProvincesController>
        [HttpGet]
        public async Task<IActionResult> Get(int provinceId)
        {
            var result = await _municipalityService.GetAllAsync(provinceId);

            return Ok(result);
        }

        // GET api/<ProvincesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int provinceId, int id)
        {
            var result = await _municipalityService.GetByIdAsync(provinceId, id);

            return Ok(result);
        }


    }
}
