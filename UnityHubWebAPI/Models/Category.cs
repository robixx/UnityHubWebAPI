using System.ComponentModel.DataAnnotations;

namespace UnityHubWebAPI.Models
{
    public class Category : BaseModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
