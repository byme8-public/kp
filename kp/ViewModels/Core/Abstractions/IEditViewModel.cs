using kp.Domain.Data.Core;

namespace kp.ViewModels.Core.Abstractions
{
    public interface IEditViewModel<TEntity>
        where TEntity : DomainEntity
    {
        TEntity Entity
        {
            get;
            set;
        }
    }
}