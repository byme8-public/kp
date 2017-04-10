using System;

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