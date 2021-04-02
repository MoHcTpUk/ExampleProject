using System.ComponentModel.DataAnnotations.Schema;
using Core.DAL.Entities;

namespace ExampleProject.DAL.Entities
{
    [Table("Examples")]
    public class ExampleEntity : AbstractEntity
    {
        public int Field { get; set; }
    }
}