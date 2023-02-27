using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Items.Models;
using Items.Interfaces;

namespace Items.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssimentController : ControllerBase
    {

        private IAssiment assimentSer;
        public AssimentController(IAssiment assiment)
        {
            this.assimentSer = assiment;
        }

        [HttpGet]
        public IEnumerable<Assiment> Get()
        {
            return this.assimentSer.GetAll();

        }

        [HttpGet("{id}")]
        public ActionResult<Assiment> Get(int id)
        {
            var a = this.assimentSer.Get(id);
            if (a == null)
                return NotFound();
             return a;
        }

        [HttpPost]
        public ActionResult Post(Assiment assiment)
        {
            this.assimentSer.Add(assiment);

            return CreatedAtAction(nameof(Post), new { id = assiment.Id }, assiment);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Assiment assiment)
        {
            if (! this.assimentSer.Update(id, assiment))
                return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete (int id)
        {
            if (! this.assimentSer.Delete(id))
                return NotFound();
            return NoContent();            
        }

    }
}
