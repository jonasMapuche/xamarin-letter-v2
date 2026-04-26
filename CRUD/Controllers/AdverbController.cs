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
        public static readonly AdverbService _adverbsService = new AdverbService("development");
        public static readonly AdverbService _adverbsServiceTest = new AdverbService("test");
        public static readonly AdverbService _adverbsServiceProduction = new AdverbService("production");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo adverb.");
        }

        [HttpPost("")]
        public async Task<IActionResult> Adverb(Circustancia circustancia)
        {
            await _adverbsService.CreateAsync(circustancia);
            await _adverbsServiceTest.CreateAsync(circustancia);
            await _adverbsServiceProduction.CreateAsync(circustancia);
            return CreatedAtAction(nameof(Get), new { id = circustancia.Id }, circustancia);
        }

        [HttpGet("all")]
        public async Task<List<Circustancia>> GetAll()
        {
            return await _adverbsService.GetAsync();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateLanguage(AtribuirCircustancia circustancia)
        {
            long result = await _adverbsService.UpdateLanguageAsync(circustancia.chave.linguagem, circustancia.atualizar.linguagem);
            result += await _adverbsServiceTest.UpdateLanguageAsync(circustancia.chave.linguagem, circustancia.atualizar.linguagem);
            result += await _adverbsServiceProduction.UpdateLanguageAsync(circustancia.chave.linguagem, circustancia.atualizar.linguagem);
            string expression = "Expression update " + result + " successfull with.";
            return Ok(expression);
        }
    }
}
