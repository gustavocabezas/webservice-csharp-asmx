using System.Data.Entity;
using WebServiceCSharp.Models;

namespace WebServiceCSharp.Repository
{
    public class UserDataContext : DbContext
    {
        public UserDataContext(string connectionString) : base(connectionString) { }

        public DbSet<User> User { get; set; }
    }
}