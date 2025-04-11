using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentenceController : ControllerBase
    {
        public static readonly SentenceService _sentencesService = new SentenceService("sentence");
        public static readonly SentenceService _sentencesService2 = new SentenceService("verb");
        public static readonly SentenceService _sentencesService3 = new SentenceService("chord");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo sentence.");
        }

        [HttpPost("")]
        public async Task<IActionResult> Sentence(Ditado ditado)
        {
            await _sentencesService.CreateAsync(ditado);
            await _sentencesService2.CreateAsync(ditado);
            await _sentencesService3.CreateAsync(ditado);
            return CreatedAtAction(nameof(Get), new { id = ditado.Id }, ditado);
        }

        [HttpGet("all")]
        public async Task<List<Ditado>> GetAll()
        {
            return await _sentencesService.GetAsync();
        }

    }
}
