using Microsoft.AspNetCore.Mvc;
using TravelAppApi.Models;
using TravelAppApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotController : ControllerBase
    {
        private readonly SpotService _spotService;

        public SpotController(SpotService spotService)
        {
            _spotService = spotService;
        }

        // GET: api/<SpotController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spot>>> GetAllSpots()
        {
            List<Spot> spots = await _spotService.GetAllSpots();

            if(spots.Count == 0)
            {
                return NotFound();
            }
            return Ok(spots);
        }

        // GET api/<SpotController>/5
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Spot?>> GetSpotbyId(string id)
        {
            Spot spot = await _spotService.GetSpotById(id);

            if(spot == null)
            {
                return NotFound();
            }
            return Ok(spot);
        }

        // GET api/<SpotController>/5
        [HttpGet("name/{name}")]
        public async Task<ActionResult<Spot?>> GetSpotbyName(string name)
        {
            Spot spot = await _spotService.GetSpotByName(name);

            if (spot == null)
            {
                return NotFound();
            }
            return Ok(spot);
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<IEnumerable<Spot>>> GetSpotbyCategory(string category)
        {
            category = category.ToLower();
            List<Spot> spots = await _spotService.GetSpotByCategory(category);
            
            if(spots.Count == 0)
            {
                return NotFound();
            }
            return Ok(spots);
        }

        [HttpGet("district/{district}")]
        public async Task<ActionResult<IEnumerable<Spot>>> GetSpotbyDistrict(string district)
        {
            district = district.ToLower();
            List<Spot> spots = await _spotService.GetSpotByDistrict(district);

            if (spots.Count == 0)
            {
                return NotFound();
            }
            return Ok(spots);
        }

        // POST api/<SpotController>
        [HttpPost]
        public async Task Post(Spot newSpot)
        {
            await _spotService.AddSpot(newSpot);
        }

        // PUT api/<SpotController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpotController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
