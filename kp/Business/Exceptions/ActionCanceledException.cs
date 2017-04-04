using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp.Business.Exceptions
{
	public class ActionCanceledException : ApplicationException
	{
		public ActionCanceledException(string message) 
			: base(message)
		{
		}
	}
}
 