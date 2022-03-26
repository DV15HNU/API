using apicomp2001.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace apicomp2001.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProgrammesController : ControllerBase
    {
        private readonly DataAccess _database;

        public ProgrammesController(DataAccess database)
        {
            _database = database;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programmes>>> GetProgrammes()
        {
            return await _database.Programmes.ToListAsync();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _database.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id)
        {
            _database.Update(id);
            return NoContent(); 
        }



    }

}
