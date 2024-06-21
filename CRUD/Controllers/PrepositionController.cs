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
        public static readonly PrepositionService _prepositionsService2 = new PrepositionService("article");
        public static readonly PrepositionService _prepositionsService3 = new PrepositionService("pronoun");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo preposition.");
        }

        [HttpPost("")]
        public async Task<IActionResult> Preposition(Juncao juncao)
        {
            await _prepositionsService.CreateAsync(juncao);
            await _prepositionsService2.CreateAsync(juncao);
            await _prepositionsService3.CreateAsync(juncao);
            return CreatedAtAction(nameof(Get), new { id = juncao.Id }, juncao);
        }

        [HttpGet("all")]
        public async Task<List<Juncao>> GetAll()
        {
            return await _prepositionsService.GetAsync();
        }
    }
}
