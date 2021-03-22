using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleProject.DAL.Entities
{
    [Table("Examples")]
    public class ExampleEntity : BaseEntity
    {
        public int Field { get; set; }
    }
}