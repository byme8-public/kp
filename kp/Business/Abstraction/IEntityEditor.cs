using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
