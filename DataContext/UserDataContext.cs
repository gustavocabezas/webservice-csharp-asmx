using System.Data.Entity;
using webservicecsharpasmx.Models;

namespace webservicecsharpasmx.Repository
{
    public class UserDataContext : DbContext
    {
        public UserDataContext(string connectionString) : base(connectionString) { }

        public DbSet<User> User { get; set; }
    }
}