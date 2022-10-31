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
            new Spot("SpotName5", "Category4", "District5") { Id = 5 }
        };

        // GET: api/<SpotController>
        [HttpGet]
        public ActionResult<IEnumerable<Spot>> Get()
        {
            return Ok(spots);
        }

        // GET api/<SpotController>/5
        [HttpGet("{id}")]
        public ActionResult<Spot> Get(int id)
        {
            Spot spot = spots.SingleOrDefault(sp => sp.Id == id);

            if(spot == null)
            {
                return NotFound();
            }

            return Ok(spot);
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
