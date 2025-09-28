using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LetterController : ControllerBase
    {
        public static readonly LetterService _lettersService = new LetterService("letter");
        public static readonly LetterService _lettersService2 = new LetterService("valence");
        public static readonly LetterService _lettersService3 = new LetterService("chord");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo letter.");
        }

        [HttpGet("all")]
        public async Task<List<Aula>> GetAll()
        {
            return await _lettersService.GetAsync();
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(Aula aula)
        {
            await _lettersService.CreateAsync(aula);
            await _lettersService2.CreateAsync(aula);
            await _lettersService3.CreateAsync(aula);
            return CreatedAtAction(nameof(Get), new { id = aula.Id }, aula);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateLanguage(AtribuirAula aula)
        {
            long result = await _lettersService.UpdateLanguageAsync(aula.chave.linguagem, aula.atualizar.linguagem);
            result += await _lettersService2.UpdateLanguageAsync(aula.chave.linguagem, aula.atualizar.linguagem);
            result += await _lettersService3.UpdateLanguageAsync(aula.chave.linguagem, aula.atualizar.linguagem);
            string expression = "Expression update " + result + " successfull with.";
            return Ok(expression);
        }
    }
}
