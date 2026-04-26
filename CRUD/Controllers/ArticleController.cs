using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        public static readonly ArticleService _articlesService = new ArticleService("development");
        public static readonly ArticleService _articlesServiceTest = new ArticleService("test");
        public static readonly ArticleService _articlesServiceProduction = new ArticleService("production");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo article.");
        }

        [HttpPost("")]
        public async Task<IActionResult> Article(Preceito preceito)
        {
            await _articlesService.CreateAsync(preceito);
            await _articlesServiceTest.CreateAsync(preceito);
            await _articlesServiceProduction.CreateAsync(preceito);
            return CreatedAtAction(nameof(Get), new { id = preceito.Id }, preceito);
        }

        [HttpGet("all")]
        public async Task<List<Preceito>> GetArticleAll()
        {
            return await _articlesService.GetAsync();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateLanguage(AtribuirJuncao juncao)
        {
            long result = await _articlesService.UpdateLanguageAsync(juncao.chave.linguagem, juncao.atualizar.linguagem);
            result += await _articlesServiceTest.UpdateLanguageAsync(juncao.chave.linguagem, juncao.atualizar.linguagem);
            result += await _articlesServiceProduction.UpdateLanguageAsync(juncao.chave.linguagem, juncao.atualizar.linguagem);
            string expression = "Expression update " + result + " successfull with.";
            return Ok(expression);
        }
    }
}
