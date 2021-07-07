using ClientMaster.Core.Models.Dtos.LocationDtos;
using ClientMaster.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientMaster.Api.Controllers
{
    [Route("api/customers/{customerId:int}/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        // GET: api/<LocationsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _locationService.GetAllAsync(customerId);

            return Ok(result);
        }

        // GET api/<LocationsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int locationId)
        {
            var result = await _locationService.GetByIdAsync(locationId);

            return Ok(result);
        }

        // POST api/<LocationsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LocationPostDto locationPost)
        {
            var result = await _locationService.AddAsync(locationPost);

            return Ok(result);
        }

        // PUT api/<LocationsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] LocationUpdateDto locationUpdate)
        {
            var result = await _locationService.UpdateAsync(locationUpdate);

            return Ok(result);
        }

        // DELETE api/<LocationsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _locationService.RemoveAsync(id);

            return Ok(result);
        }
    }
}
