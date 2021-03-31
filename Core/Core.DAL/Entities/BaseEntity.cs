using System.ComponentModel.DataAnnotations;

namespace Core.DAL.Entities
{
    public abstract class BaseEntity : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}
