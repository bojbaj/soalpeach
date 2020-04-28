using System.Threading.Tasks;
using CountMe.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CountMe.Controllers
{
    [ApiController]
    [Route("/")]
    public class CountController : ControllerBase
    {
        private readonly IDb _db;
        public CountController(IDb db)
        {
            _db = db;
        }
        
        [HttpPost]
        public Task<int> Post([FromBody] int input_number)
        {            
            return Task.FromResult(_db.SetNewNumber(input_number));
        }

        [HttpGet("Count")]
        public Task<int> Get()
        {
            return Task.FromResult(_db.GetSumOfNumbers());
        }
    }
}
