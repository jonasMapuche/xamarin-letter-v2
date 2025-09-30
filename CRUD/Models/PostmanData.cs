namespace CRUD.Models
{
    public class PostmanData
    {
        public string owner { get; set; }
        public string lastUpdatedBy { get; set; }
        public long lastRevision { get; set; }
        public string folder { get; set; }
        public string collection { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string dataMode { get; set; }
        public string rawModeData { get; set; }
        public string method { get; set; }
        public string url { get; set; }
        //public bool dataDisabled { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }
}
