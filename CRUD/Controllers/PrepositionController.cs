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
        public static readonly PrepositionService _prepositionsService = new PrepositionService("development");
        public static readonly PrepositionService _prepositionsServiceTest = new PrepositionService("test");
        public static readonly PrepositionService _prepositionsServiceProduction = new PrepositionService("production");

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
            await _prepositionsServiceTest.CreateAsync(juncao);
            await _prepositionsServiceProduction.CreateAsync(juncao);
            return CreatedAtAction(nameof(Get), new { id = juncao.Id }, juncao);
        }

        [HttpGet("all")]
        public async Task<List<Juncao>> GetAll()
        {
            return await _prepositionsService.GetAsync();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateLanguage(AtribuirJuncao juncao)
        {
            long result = await _prepositionsService.UpdateLanguageAsync(juncao.chave.linguagem, juncao.atualizar.linguagem);
            result += await _prepositionsServiceTest.UpdateLanguageAsync(juncao.chave.linguagem, juncao.atualizar.linguagem);
            result += await _prepositionsServiceProduction.UpdateLanguageAsync(juncao.chave.linguagem, juncao.atualizar.linguagem);
            string expression = "Expression update " + result + " successfull with.";
            return Ok(expression);
        }
    }
}
