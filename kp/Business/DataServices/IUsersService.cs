using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.DataServies.Entities;

namespace kp.Business.DataServices
{
	public interface IUserService : IEntityService<User>
	{
	}
}
