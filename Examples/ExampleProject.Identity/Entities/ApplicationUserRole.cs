using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ExampleProject.Identity.Entities
{
    [Table("UserRoles", Schema = "Identity")]
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        public virtual ApplicationUser User { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        public virtual ApplicationRole Role { get; set; }
    }
}
