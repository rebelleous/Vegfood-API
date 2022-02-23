using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VegFoods.Core.IRepositories;
using VegFoods.Core.Services;
using VegFoods.Core.UnitOfWork;

namespace VegFoods.Services.Services
{
    public class Service<T> : IService<T> where T : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;

        public Service(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            return entity;
        }

        public T Update(T entity)
        {
            T updateEntity = _repository.Update(entity);

            _unitOfWork.Commit();

            return updateEntity;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _repository.Find(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
        }

       
    }
}
