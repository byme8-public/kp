using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;

namespace kp.ViewModels.Core
{
	public class EntityListViewModel<TEntity> : ViewModel
	{
		public EntityListViewModel(IEntityService<TEntity> service, IEntityFactory<TEntity> factory)
		{
			Task.Run(async () =>
			{
				var users = await service.Get();
			});
		}
	}
}
