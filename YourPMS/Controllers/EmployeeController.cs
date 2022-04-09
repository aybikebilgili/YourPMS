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
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext context;

        public EmployeeController(AppDbContext context)
        {
            this.context = context;
        }


        // GET: api/<ContactController>
        [HttpGet]
        public List<Employees> Get()
        {
            return context.Employees.ToList();
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public ActionResult<Employees> GetById(int id)
        {
            var item = context.Employees.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employees model)
        {
            if (model != null)
            {
                context.Employees.Add(model);
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
        public IActionResult Put(int id, [FromBody] Employees model)
        {
            if (model == null || model.employeeID != id)
            {
                return BadRequest();
            }

            var item = context.Employees.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            item.employeeID = model.employeeID;
            item.employeeName = model.employeeName;
            item.age = model.age;
            item.phoneNo = model.phoneNo;
            item.position = model.position;

            context.Employees.Update(item);
            context.SaveChanges();

            return Ok(item);
        }


        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = context.Employees.Find(id);
            if (item == null)
            {
                return NotFound(new { Success = true });

            }

            context.Employees.Remove(item);
            context.SaveChanges();

            return Ok(new { Success = true });
        }

        




    }
}
