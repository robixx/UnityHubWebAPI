using Microsoft.EntityFrameworkCore;
using UnityHubWebAPI.Models;

namespace UnityHubWebAPI.Data
{
    public class DataBaseConnection : DbContext
    {
        public DataBaseConnection(DbContextOptions<DataBaseConnection> options)
         : base(options)
        {
        }

        public DbSet<LoginUser> LoginUser { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}
