using System.Collections.Generic;

namespace Letter.Models
{
    public class LicaoModel
    {
        public int order {  get; set; }
        public string team { get; set; }
        public List<WordModel> lecture { get; set; }
    }
}