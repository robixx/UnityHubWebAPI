using System.ComponentModel.DataAnnotations;

namespace UnityHubWebAPI.Models
{
    public class Company : BaseModel
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
    }
}
