using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourPMS.Models;

namespace YourPMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        private readonly AppDbContext context;

        public BlockController(AppDbContext context)
        {
            this.context = context;
        }


        // GET: api/<ContactController>
        [HttpGet]
        public List<Blocks> Get()
        {
            return context.Blocks.ToList();
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public ActionResult<Blocks> GetById(int id)
        {
            var item = context.Blocks.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Blocks model)
        {
            if (model != null)
            {
                context.Blocks.Add(model);
                context.SaveChanges();
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }


       

      



    }
}
