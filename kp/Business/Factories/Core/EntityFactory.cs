using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;

namespace kp.Business.Factories.Core
{
	public class EntityFactory<TEntity> : IEntityFactory<TEntity>
	{
		public Task<TEntity> New()
		{
			return null;
		}
	}
}
