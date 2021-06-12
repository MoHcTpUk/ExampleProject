using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ExampleProject.Identity.Entities
{
    [Table("RoleClaims", Schema = "Identity")]
    public class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
    }
}
