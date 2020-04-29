using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CountMe.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CountMe.Controllers
{
    [ApiController]
    public class CountController : ControllerBase
    {
        private readonly IDb _db;
        public CountController(IDb db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("/")]
        public Task<int> Post()
        {
            int input_number = Convert.ToInt32(Request.Form.Keys.First());
            return Task.FromResult(_db.SetNewNumber(Convert.ToInt32(input_number)));
        }

        [HttpGet]
        [Route("/count")]
        public Task<int> Get()
        {
            return Task.FromResult(_db.GetSumOfNumbers());
        }
    }
}
