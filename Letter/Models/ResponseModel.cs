using System.Collections.Generic;

namespace Letter.Models
{
    public class ResponseModel
    {
        public string Kind { get; set; }
        public List<WordModel> Word { get; set; }
        public int Sender { get; set; }
    }
}