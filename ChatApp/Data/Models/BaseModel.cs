namespace ChatApp.Data.Models
{
    public class BaseModel
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool Active { get; set; }
    }
}
