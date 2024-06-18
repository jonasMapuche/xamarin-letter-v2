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
        public static readonly ArticleService _articlesService = new ArticleService("article");
        public static readonly ArticleService _articlesService2 = new ArticleService("noten");
        public static readonly ArticleService _articlesService3 = new ArticleService("malware");

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
            await _articlesService2.CreateAsync(preceito);
            await _articlesService3.CreateAsync(preceito);
            return CreatedAtAction(nameof(Get), new { id = preceito.Id }, preceito);
        }

        [HttpGet("all")]
        public async Task<List<Preceito>> GetArticleAll()
        {
            return await _articlesService.GetAsync();
        }

    }
}
