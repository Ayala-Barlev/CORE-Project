using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Items.Models;

namespace Items.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssimentController : ControllerBase
    {


        [HttpGet]
        public IEnumerable<Assiment> Get()
        {
            return AssimentService.GetAll();

        }

        [HttpGet("{id}")]
        public ActionResult<Assiment> Get(int id)
        {
            var a = AssimentService.Get(id);
            if (a == null)
                return NotFound();
             return a;
        }

        [HttpPost]
        public ActionResult Post(Assiment assiment)
        {
            AssimentService.Add(assiment);

            return CreatedAtAction(nameof(Post), new { id = assiment.Id }, assiment);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Assiment assiment)
        {
            if (! AssimentService.Update(id, assiment))
                return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete (int id)
        {
            if (! AssimentService.Delete(id))
                return NotFound();
            return NoContent();            
        }

    }
}
