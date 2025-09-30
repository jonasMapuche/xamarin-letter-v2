using System.Collections.Generic;

namespace CRUD.Models
{
    public class PostmanCollection
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<PostmanCollection> item { get; set; }
        public string id_collection { get; set; }
        public string uid { get; set; }
    }
}
