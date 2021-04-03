using Core.DAL.Entities;
using Core.DAL.Repository;

namespace ExampleProject.DAL.Interfaces.Repository
{
    public interface IExampleRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
    }
}