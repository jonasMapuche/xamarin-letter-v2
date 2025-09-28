using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumeralController : ControllerBase
    {
        public static readonly NumeralService _numeralsService = new NumeralService("numeral");
        public static readonly NumeralService _numeralsService2 = new NumeralService("activity");
        public static readonly NumeralService _numeralsService3 = new NumeralService("periodic");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo numeral.");
        }

        [HttpPost("")]
        public async Task<IActionResult> Adverb(Algarismo algarismo)
        {
            await _numeralsService.CreateAsync(algarismo);
            await _numeralsService2.CreateAsync(algarismo);
            await _numeralsService3.CreateAsync(algarismo);
            return CreatedAtAction(nameof(Get), new { id = algarismo.Id }, algarismo);
        }

        [HttpGet("all")]
        public async Task<List<Algarismo>> GetAll()
        {
            return await _numeralsService.GetAsync();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateLanguage(AtribuirAlgarismo algarismo)
        {
            long result = await _numeralsService.UpdateLanguageAsync(algarismo.chave.linguagem, algarismo.atualizar.linguagem);
            result += await _numeralsService2.UpdateLanguageAsync(algarismo.chave.linguagem, algarismo.atualizar.linguagem);
            result += await _numeralsService3.UpdateLanguageAsync(algarismo.chave.linguagem, algarismo.atualizar.linguagem);
            string expression = "Expression update " + result + " successfull with.";
            return Ok(expression);
        }
    }
}
