using Microsoft.AspNetCore.Mvc;
using TravelAppApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotController : ControllerBase
    {
        private List<Spot> spots = new List<Spot>
        { 
            new Spot("SpotName1", "Category1", "District1") { Id = 1 }, 
            new Spot("SpotName2", "Category2", "District2") { Id = 2 },
            new Spot("SpotName3", "Category2", "District3") { Id = 3 },
            new Spot("SpotName4", "Category3", "District4") { Id = 4 },
            new Spot("SpotName5", "Category4", "District5") { Id = 5 },
            new Spot("SpotName6", "Category5", "District5") { Id = 6 },
            new Spot("SpotName7", "Category6", "District5") { Id = 7 },
            new Spot("SpotName8", "Category2", "District1") { Id = 8 },
            new Spot("SpotName9", "Category3", "District3") { Id = 9 },
            new Spot("SpotName10", "Category4", "District3") { Id = 10 }
        };

        // GET: api/<SpotController>
        [HttpGet]
        public ActionResult<IEnumerable<Spot>> GetAllSpots()
        {
            return Ok(spots);
        }

        // GET api/<SpotController>/5
        [HttpGet("id/{id}")]
        public ActionResult<Spot> GetSpotbyId(int id)
        {
            Spot spot = spots.SingleOrDefault(sp => sp.Id == id);

            if(spot == null)
            {
                return NotFound();
            }

            return Ok(spot);
        }

        [HttpGet("category/{category}")]
        public ActionResult<IEnumerable<Spot>> GetSpotbyCategory(string category)
        {
            category = category.ToLower();
            List<Spot> categorySpots = spots.Where(sp => sp.Category.ToLower() == category).ToList();

            if(categorySpots.Count == 0 || categorySpots == null)
            {
                return NotFound();
            }

            return Ok(categorySpots);
        }

        [HttpGet("district/{district}")]
        public ActionResult<IEnumerable<Spot>> GetSpotbyDistrict(string district)
        {
            district = district.ToLower();
            List<Spot> districtSpots = spots.Where(sp => sp.District.ToLower() == district).ToList();

            if (districtSpots.Count == 0 || districtSpots == null)
            {
                return NotFound();
            }

            return Ok(districtSpots);
        }

        // POST api/<SpotController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

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
