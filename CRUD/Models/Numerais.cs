using SQLite;

namespace CRUD.Models
{
    public class Numerais
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public int initial { get; set; }
        public string language { get; set; }
        public string type { get; set; }
    }
}
