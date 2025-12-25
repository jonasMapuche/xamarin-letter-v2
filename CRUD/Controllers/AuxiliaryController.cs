using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AuxiliaryController : ControllerBase
    {
        public static readonly AuxiliaryService _auxiliarysService = new AuxiliaryService("auxiliary");
        public static readonly AuxiliaryService _auxiliarysService2 = new AuxiliaryService("pronoun");
        public static readonly AuxiliaryService _auxiliarysService3 = new AuxiliaryService("numeral");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo auxiliary verb.");
        }

        [HttpPost("")]
        public async Task<IActionResult> Auxiliary(Assistant assistant)
        {
            await _auxiliarysService.CreateAsync(assistant);
            await _auxiliarysService2.CreateAsync(assistant);
            await _auxiliarysService3.CreateAsync(assistant);
            return CreatedAtAction(nameof(Get), new { id = assistant.Id }, assistant);
        }

        [HttpGet("all")]
        public async Task<List<Assistant>> GetAll()
        {
            return await _auxiliarysService.GetAsync();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateLanguage(AtribuirAssistente assistente)
        {
            long result = await _auxiliarysService.UpdateLanguageAsync(assistente.chave.linguagem, assistente.atualizar.linguagem);
            result += await _auxiliarysService2.UpdateLanguageAsync(assistente.chave.linguagem, assistente.atualizar.linguagem);
            result += await _auxiliarysService3.UpdateLanguageAsync(assistente.chave.linguagem, assistente.atualizar.linguagem);
            string expression = "Expression update " + result + " successfull with.";
            return Ok(expression);
        }
    }
}
