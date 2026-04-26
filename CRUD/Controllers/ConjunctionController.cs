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
        public static readonly ConjunctionService _conjunctionsService = new ConjunctionService("development");
        public static readonly ConjunctionService _conjunctionsServiceTest = new ConjunctionService("test");
        public static readonly ConjunctionService _conjunctionsServiceProduction = new ConjunctionService("production");

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
            await _conjunctionsServiceTest.CreateAsync(ligacao);
            await _conjunctionsServiceProduction.CreateAsync(ligacao);
            return CreatedAtAction(nameof(Get), new { id = ligacao.Id }, ligacao);
        }

        [HttpGet("all")]
        public async Task<List<Ligacao>> GetAll()
        {
            return await _conjunctionsService.GetAsync();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateLanguage(AtribuirLigacao ligacao)
        {
            long result = await _conjunctionsService.UpdateLanguageAsync(ligacao.chave.linguagem, ligacao.atualizar.linguagem);
            result += await _conjunctionsServiceTest.UpdateLanguageAsync(ligacao.chave.linguagem, ligacao.atualizar.linguagem);
            result += await _conjunctionsServiceProduction.UpdateLanguageAsync(ligacao.chave.linguagem, ligacao.atualizar.linguagem);
            string expression = "Expression update " + result + " successfull with.";
            return Ok(expression);
        }
    }
}
