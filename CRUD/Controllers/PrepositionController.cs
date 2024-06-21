using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrepositionController : ControllerBase
    {
        public static readonly PrepositionService _prepositionsService = new PrepositionService("preposition");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo preposition.");
        }

        [HttpPost("")]
        public async Task<IActionResult> Preposition(Juncao junaco)
        {
            await _prepositionsService.CreateAsync(junaco);
            return CreatedAtAction(nameof(Get), new { id = junaco.Id }, junaco);
        }

        [HttpGet("all")]
        public async Task<List<Juncao>> GetAll()
        {
            return await _prepositionsService.GetAsync();
        }
    }
}
