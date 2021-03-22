using ExampleProject.DAL.EF;
using ExampleProject.DAL.Entities;

namespace ExampleProject.App.DI
{
    public static partial class Configurator
    {
        private static void InitDb(ApplicationDbContext context)
        {
            var entity = new ExampleEntity()
            {
                Id = 1,
                Field = 10
            };

            context.Bases.Add(entity);
            context.SaveChanges();
        }
    }
}