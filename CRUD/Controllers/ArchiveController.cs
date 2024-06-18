using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArchiveController : ControllerBase
    {
        public static readonly SQLiteService _sQLiteService = new SQLiteService();
        public static readonly LetterService _lettersService = new LetterService("letter");

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(500);
            return Ok("Expression building program based on lessons! Modulo archive.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aula>> GetContent(string id)
        {
            Aula aula = await _lettersService.GetSentenceSimpleAsync(id);
            if (aula is null)
                return NotFound();
            string fileName = id + ".json";
            Conteudo content = new();
            content = aula.conteudo;
            Arquivo arquivo = new Arquivo
            {
                nome = aula.nome,
                conteudo = content
            };
            using (var stream = new System.IO.FileStream(fileName, System.IO.FileMode.Create))
            {
                var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Arquivo));
                serializer.WriteObject(stream, arquivo);
            }
            return aula;
        }

        [HttpPost("")]
        public async Task<IActionResult> SQLite()
        {
            List<Aula> aula = await _lettersService.GetAsync();
            await _sQLiteService.CreateAsync(aula);
            return Ok("SQLite build with ten word class.");
        }

    }
}
