using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostmanController : ControllerBase
    {
        public static readonly PostmanService _postmansService = new PostmanService();

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo postman.");
        }

        [HttpGet("all")]
        public async Task<string> GetAll()
        {
            return await _postmansService.GetAsync();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateLanguage(AtribuirLigacao ligacao)
        {
            long result = 0; 
            //result = await _postmansService.UpdateLanguageAsync(ligacao.chave.linguagem, ligacao.atualizar.linguagem);
            string expression = "Expression update " + result + " successfull with.";
            return Ok(expression);
        }
    }
}
