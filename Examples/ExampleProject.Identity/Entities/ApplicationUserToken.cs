using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ExampleProject.Identity.Entities
{
    [Table("UserTokens", Schema = "Identity")]
    public class ApplicationUserToken : IdentityUserToken<int>
    {
    }
}
