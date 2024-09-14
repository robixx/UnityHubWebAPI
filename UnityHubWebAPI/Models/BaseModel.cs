namespace UnityHubWebAPI.Models
{
    public class BaseModel
    {
        public string CreateBy { get; set; } = string.Empty;
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
