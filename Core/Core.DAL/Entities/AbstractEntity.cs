using System.ComponentModel.DataAnnotations;

namespace Core.DAL.Entities
{
    public abstract class AbstractEntity : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}
