using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitController : ControllerBase
    {
        private readonly List<string> _fruits = new()
        {
            "Lemon",
            "Banana",
        };

        [HttpGet]
        public IEnumerable<string> GetFruits()
        {
            return _fruits;
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetFruit(int id)
        {
            if (id >= 0 && id < _fruits.Count)
            {
                return _fruits[id];
            }

            return NotFound();
        }
    }
}
