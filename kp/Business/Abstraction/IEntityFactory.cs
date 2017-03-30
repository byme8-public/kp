using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp.Business.Abstraction
{
	public interface IEntityFactory<TEntity>
	{
		Task<TEntity> New();
	}
}
