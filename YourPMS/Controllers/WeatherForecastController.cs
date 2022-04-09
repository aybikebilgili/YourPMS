using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourPMS.Models;

namespace YourPMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly AppDbContext context;
        public WeatherForecastController(AppDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, "  ");
        }
    }
}
