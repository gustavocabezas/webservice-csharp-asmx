using System.Data.Entity;
using WebServiceCSharp.Models;

namespace WebServiceCSharp.Repository
{
    public class YourDataContext : DbContext
    {
        public YourDataContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<UserBO> User { get; set; }
    }
}