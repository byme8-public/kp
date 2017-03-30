using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace kp.Business.Abstraction
{
	public interface IEntityService<TEntity>
	{
		[Post("")]
		Task<TEntity> Add([Body]TEntity entity);

		[Put("")]
		Task<TEntity> Update([Body]TEntity entity);

		[Delete("")]
		Task Remove(Guid id);

		[Get("")]
		Task<IEnumerable<TEntity>> Get();
	}
}
