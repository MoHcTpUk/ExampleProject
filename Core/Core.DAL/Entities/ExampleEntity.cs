using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DAL.Entities
{
    [Table("Examples")]
    public class ExampleEntity : BaseEntity
    {
        public int Field { get; set; }
    }
}