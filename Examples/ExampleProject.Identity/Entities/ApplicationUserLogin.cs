using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ExampleProject.Identity.Entities
{
    [Table("UserLogins", Schema = "Identity")]
    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
    }
}
