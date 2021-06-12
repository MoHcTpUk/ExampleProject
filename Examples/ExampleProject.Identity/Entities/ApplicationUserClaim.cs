using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ExampleProject.Identity.Entities
{
    [Table("UserClaims", Schema = "Identity")]
    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
    }
}
