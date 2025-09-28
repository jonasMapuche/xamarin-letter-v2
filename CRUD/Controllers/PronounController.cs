using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PronounController : ControllerBase
    {
        public static readonly PronounService _pronounsService = new PronounService("pronoun");
        public static readonly PronounService _pronounsService2 = new PronounService("periodic");
        public static readonly PronounService _pronounsService3 = new PronounService("artless");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo pronoun.");
        }

        [HttpPost("")]
        public async Task<IActionResult> Pronoun(Estoutro estoutro)
        {
            await _pronounsService.CreateAsync(estoutro);
            await _pronounsService2.CreateAsync(estoutro);
            await _pronounsService3.CreateAsync(estoutro);
            return CreatedAtAction(nameof(Get), new { id = estoutro.Id }, estoutro);
        }

        [HttpGet("all")]
        public async Task<List<Estoutro>> GetPronounAll()
        {
            return await _pronounsService.GetAsync();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateLanguage(AtribuirEstoutro estoutro)
        {
            long result = await _pronounsService.UpdateLanguageAsync(estoutro.chave.linguagem, estoutro.atualizar.linguagem);
            result += await _pronounsService2.UpdateLanguageAsync(estoutro.chave.linguagem, estoutro.atualizar.linguagem);
            result += await _pronounsService3.UpdateLanguageAsync(estoutro.chave.linguagem, estoutro.atualizar.linguagem);
            string expression = "Expression update " + result + " successfull with.";
            return Ok(expression);
        }
    }
}
