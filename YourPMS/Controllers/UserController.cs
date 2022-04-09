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
    public class UserController : ControllerBase
    {
        private readonly AppDbContext context;

        public UserController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public List<Users> Get()
        {
            return context.Users.ToList();
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public ActionResult<Users> GetById(int id)
        {
            var item = context.Users.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST api/<ContactController>
        [HttpPost]
        public IActionResult Post([FromBody] Users model)
        {
            if (model != null)
            {
                context.Users.Add(model);
                context.SaveChanges();
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Users model)
        {
            if (model == null || model.userID != id)
            {
                return BadRequest();
            }

            var item = context.Users.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            item.userID = model.userID;
            item.nameSurname = model.nameSurname;
            item.blockID = model.blockID;
            item.numberOfPeople = model.numberOfPeople;
            item.phoneNo = model.phoneNo;
            item.email = model.email;
            item.password = model.password;
            item.isTenant = model.isTenant;
            item.hasCar = model.hasCar;
            item.isManager = model.isManager;

            context.Users.Update(item);
            context.SaveChanges();

            return Ok(item);
        }


        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = context.Users.Find(id);
            if (item == null)
            {
                return NotFound(new { Success = true });

            }

            context.Users.Remove(item);
            context.SaveChanges();

            return Ok(new { Success = true });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Users model)
        {
            if (model != null)
            {
                Users user = context.Users.Where(c => c.email == model.email && c.password == model.password).FirstOrDefault();


                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
