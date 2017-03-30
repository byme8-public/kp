using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.DataServies.Entities.Core;

namespace kp.DataServies.Entities
{
	public class User : Entity
	{
		public string Login
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}
	}
}
