using System.Threading.Tasks;

namespace kp.Business.Abstraction
{
    public interface IEntityFactory<TEntity>
    {
        Task<TEntity> New();
    }
}