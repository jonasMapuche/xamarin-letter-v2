using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdverbController : ControllerBase
    {
        public static readonly AdverbService _adverbsService = new AdverbService("adverb");
        public static readonly AdverbService _adverbsService2 = new AdverbService("activity");
        public static readonly AdverbService _adverbsService3 = new AdverbService("periodic");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo adverb.");
        }

        [HttpPost("")]
        public async Task<IActionResult> Adverb(Modificador modificador)
        {
            await _adverbsService.CreateAsync(modificador);
            await _adverbsService2.CreateAsync(modificador);
            await _adverbsService3.CreateAsync(modificador);
            return CreatedAtAction(nameof(Get), new { id = modificador.Id }, modificador);
        }

        [HttpGet("all")]
        public async Task<List<Modificador>> GetAll()
        {
            return await _adverbsService.GetAsync();
        }


    }
}
