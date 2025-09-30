using System.Collections.Generic;

namespace CRUD.Models
{
    public class PostmanMeta
    {
        public string model { get; set; }
        public bool populate { get; set; }
        public bool changeset { get; set; }
        public string action { get; set; }
    }
}
