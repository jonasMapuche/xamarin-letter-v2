using System.Collections.Generic;

namespace CRUD.Models
{
    public class PostmanRequest
    {
        public string model_id { get; set; }
        public PostmanMeta meta { get; set; }
        public PostmanData data { get; set; }
    }
}
