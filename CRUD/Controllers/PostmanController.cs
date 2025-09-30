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
        public async Task<List<PostmanCollection>> GetAll()
        {
            List<string> collections = new List<string>();
            collections.Add("verb");
            List<string> folders = new List<string>();
            folders.Add("español");
            return await _postmansService.GetAsync(collections, folders);
        }

        [HttpPut("")]
        public async Task<List<PostmanRequest>> UpdateLanguage()
        {
            //long result = 0;
            List<string> collections = new List<string>();
            collections.Add("verb_copy_2");
            List<string> folders = new List<string>();
            folders.Add("español");
            string value = "espanõl";
            string replace = "español";
            //result = await _postmansService.UpdateLanguageAsync(collections, folders, value, replace);
            //string expression = "Expression update " + result + " successfull with.";
            //return Ok(expression);
            return await _postmansService.UpdateLanguageAsync(collections, folders, value, replace);
        }
    }
}
