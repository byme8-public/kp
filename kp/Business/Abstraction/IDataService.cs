using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace kp.Business.Abstraction
{
    public interface IDataService<TEntity>
    {
        [Post("")]
        Task<TEntity> Add(TEntity entity);

        [Put("")]
        Task<TEntity> Update(TEntity entity);

        [Delete("")]
        Task Remove(Guid id);

        [Get("")]
        Task<IEnumerable<TEntity>> GetAll();

        [Get("/{id}")]
        Task<TEntity> GetById(Guid id);
    }
}