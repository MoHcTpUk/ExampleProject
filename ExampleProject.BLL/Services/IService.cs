using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleProject.BLL.Services
{
    public interface IService<out TEntity, TDTO> where TDTO : class
    {
        IEnumerable<TDTO> Select(Func<TEntity, bool> predicate);
        Task<TDTO> Create(TDTO dto);
        Task<TDTO> Update(TDTO dto);
        Task<bool> Delete(int id);
    }
}