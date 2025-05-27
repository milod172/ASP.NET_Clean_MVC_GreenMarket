using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GreenMarket.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public virtual Cart? Cart { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = [];
    }
}
