using System;

namespace webservicecsharpasmx.Models
{
    public class User
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string TempPassword { get; set; } = String.Empty;
        public DateTime LastLogin { get; set; }
        public int StatusId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
