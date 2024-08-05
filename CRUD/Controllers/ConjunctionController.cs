using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConjunctionController : ControllerBase
    {
        public static readonly ConjunctionService _conjunctionsService = new ConjunctionService("conjunction");
        public static readonly ConjunctionService _conjunctionsService2 = new ConjunctionService("preposition");
        public static readonly ConjunctionService _conjunctionsService3 = new ConjunctionService("valence");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo conjunction.");
        }

        [HttpPost("")]
        public async Task<IActionResult> Conjunction(Ligacao ligacao)
        {
            await _conjunctionsService.CreateAsync(ligacao);
            await _conjunctionsService2.CreateAsync(ligacao);
            await _conjunctionsService3.CreateAsync(ligacao);
            return CreatedAtAction(nameof(Get), new { id = ligacao.Id }, ligacao);
        }

        [HttpGet("all")]
        public async Task<List<Ligacao>> GetAll()
        {
            return await _conjunctionsService.GetAsync();
        }

    }
}
