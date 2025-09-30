using System.Collections.Generic;

namespace CRUD.Models
{
    public class PostmanFolder
    {
        public PostmanInfo info { get; set; }
        public List<PostmanCollection> item { get; set; }
    }
}
