using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VerbController : ControllerBase
    {
        public static readonly VerbService _verbsService = new VerbService("development");
        public static readonly VerbService _verbsServiceTest = new VerbService("test");
        public static readonly VerbService _verbsServiceProduction = new VerbService("production");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo verb.");
        }

        [HttpPost("")]
        public async Task<IActionResult> Verb(Elocucao elocucao)
        {
            await _verbsService.CreateAsync(elocucao);
            await _verbsServiceTest.CreateAsync(elocucao);
            await _verbsServiceProduction.CreateAsync(elocucao);
            return CreatedAtAction(nameof(Get), new { id = elocucao.Id }, elocucao);
        }

        [HttpGet("all")]
        public async Task<List<Elocucao>> GetAll()
        {
            return await _verbsService.GetAsync();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateLanguage(AtribuirElocucao elocucao)
        {
            long result = await _verbsService.UpdateLanguageAsync(elocucao.chave.linguagem, elocucao.atualizar.linguagem);
            result += await _verbsServiceTest.UpdateLanguageAsync(elocucao.chave.linguagem, elocucao.atualizar.linguagem);
            result += await _verbsServiceProduction.UpdateLanguageAsync(elocucao.chave.linguagem, elocucao.atualizar.linguagem);
            string expression = "Expression update " + result + " successfull with.";
            return Ok(expression);
        }
    }
}
