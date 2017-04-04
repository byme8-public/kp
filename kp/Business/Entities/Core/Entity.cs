using System;

namespace kp.DataServies.Entities.Core
{
	public class Entity
	{
		public Guid Id
		{
			get;
			set;
		}

		public bool IsSameEntity(Entity entity)
		{
			return entity.Id == this.Id;
		}
	}
}