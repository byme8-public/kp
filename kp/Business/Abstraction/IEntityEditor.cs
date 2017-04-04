using System.Threading.Tasks;
using kp.DataServies.Entities.Core;

namespace kp.Business.Abstraction
{
	public interface IEntityEditor<TEntity>
		where TEntity : Entity
	{
		Task<TEntity> Edit(TEntity entity);
	}
}