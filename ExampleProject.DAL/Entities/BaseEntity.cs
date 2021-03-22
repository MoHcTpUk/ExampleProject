using System.ComponentModel.DataAnnotations;

namespace ExampleProject.DAL.Entities
{
    public abstract class BaseEntity : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}
