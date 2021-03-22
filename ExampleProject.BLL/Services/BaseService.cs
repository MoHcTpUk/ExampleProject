using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExampleProject.DAL.Entities;
using ExampleProject.DAL.Repository;

namespace ExampleProject.BLL.Services
{
    public abstract class BaseService<TEntity, TDTO> : IService<TEntity, TDTO> where TEntity : BaseEntity where TDTO : class
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity> _repository;

        protected BaseService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TDTO> Create(TDTO dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity = await _repository.Create(entity);
            var createdEntityDto = _mapper.Map<TDTO>(entity);

            return createdEntityDto;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public IEnumerable<TDTO> Select(Func<TEntity, bool> predicate)
        {
            var entities = _repository.Find(predicate);
            var entitiesDto = _mapper.Map<IEnumerable<TDTO>>(entities);

            return entitiesDto;
        }

        public async Task<TDTO> Update(TDTO dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity = await _repository.Update(entity);
            var updatedEntityDto = _mapper.Map<TDTO>(entity);

            return updatedEntityDto;
        }
    }
}