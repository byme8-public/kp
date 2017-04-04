using kp.DataServies.Entities.Core;

namespace kp.ViewModels.Core.Abstractions
{
	public interface IEditViewModel<TEntity>
		where TEntity : Entity
	{
		TEntity Entity
		{
			get;
			set;
		}
	}
}