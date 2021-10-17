using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ExampleProject.Identity.Entities
{
    [Table("UserRoles", Schema = "Identity")]
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        /// <summary>
        /// Gets or sets the primary key of the user that is linked to a role.
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [Required]
        public new int UserId { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the role that is linked to the user.
        /// </summary>
        /// 
        [Key]
        [Column(Order = 2)]
        [Required]
        public new int RoleId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("RoleId")]
        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}
