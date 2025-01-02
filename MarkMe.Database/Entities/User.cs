using System.ComponentModel.DataAnnotations;

namespace MarkMe.Database.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
    }
}
