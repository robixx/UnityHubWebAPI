using System.ComponentModel.DataAnnotations;

namespace UnityHubWebAPI.Models
{
    public class LoginUser
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public string Email { get; set; }
        public string CREATE_BY { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime UPDATE_DATE { get; set; }
    }
}
