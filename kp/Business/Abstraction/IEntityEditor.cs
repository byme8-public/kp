using System.Threading.Tasks;
using kp.Domain.Data.Core;

namespace kp.Business.Abstraction
{
    public interface IEntityEditor<TEntity>
        where TEntity : DomainEntity
    {
        Task<TEntity> Edit(TEntity entity);
    }
}