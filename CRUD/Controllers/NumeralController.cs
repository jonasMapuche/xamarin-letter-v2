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
        public static readonly NumeralService _numeralsService = new NumeralService("development");
        public static readonly NumeralService _numeralsServiceTest = new NumeralService("test");
        public static readonly NumeralService _numeralsServiceProduction = new NumeralService("production");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo numeral.");
        }

        [HttpPost("")]
        public async Task<IActionResult> Numeral(Algarismo algarismo)
        {
            await _numeralsService.CreateAsync(algarismo);
            await _numeralsServiceTest.CreateAsync(algarismo);
            await _numeralsServiceProduction.CreateAsync(algarismo);
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
            result += await _numeralsServiceTest.UpdateLanguageAsync(algarismo.chave.linguagem, algarismo.atualizar.linguagem);
            result += await _numeralsServiceProduction.UpdateLanguageAsync(algarismo.chave.linguagem, algarismo.atualizar.linguagem);
            string expression = "Expression update " + result + " successfull with.";
            return Ok(expression);
        }
    }
}
