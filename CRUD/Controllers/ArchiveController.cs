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
        public static readonly SQLiteService _SQLiteService = new SQLiteService();
        public static readonly LetterService _lettersService = new LetterService("letter");
        public static readonly PronounService _pronounsService = new PronounService("pronoun");
        public static readonly ArticleService _articlesService = new ArticleService("article");
        public static readonly PrepositionService _prepositionsService = new PrepositionService("preposition");
        public static readonly ConjunctionService _conjunctionsService = new ConjunctionService("conjunction");
        public static readonly AdverbService _adverbsService = new AdverbService("adverb");
        public static readonly NumeralService _numeralsService = new NumeralService("numeral");
        public static readonly VerbService _verbsService = new VerbService("verb");
        public static readonly AuxiliaryService _auxiliarysService = new AuxiliaryService("auxiliary");
        public static readonly SentenceService _sentencesService = new SentenceService("sentence");

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
            List<Estoutro> pronome = await _pronounsService.GetAsync();
            List<Preceito> artigo = await _articlesService.GetAsync();
            List<Juncao> preposicao = await _prepositionsService.GetAsync();
            List<Ligacao> conjunction = await _conjunctionsService.GetAsync();
            List<Circustancia> adverb = await _adverbsService.GetAsync();
            List<Algarismo> numeral = await _numeralsService.GetAsync();
            List<Elocucao> verbo = await _verbsService.GetAsync();
            List<Assistant> auxiliar = await _auxiliarysService.GetAsync();
            List<Ditado> sentenca = await _sentencesService.GetAsync();
            await _SQLiteService.CreateAsync(aula, pronome, artigo, preposicao, conjunction, adverb, numeral, verbo, auxiliar, sentenca);
            Message message = new Message();
            message.text = "SQLite build with ten word class.";
            message.path = _SQLiteService.PathSQLite;
            return Ok(message);
        }

    }
}
