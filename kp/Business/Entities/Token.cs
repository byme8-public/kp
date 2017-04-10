using System;
using kp.DataServies.Entities;
using kp.DataServies.Entities.Core;

namespace kp.Business.Entities
{
    public class Token : Entity
    {
        public DateTime ExpireDate
        {
            get;
            set;
        }

        public User User
        {
            get;
            set;
        }
    }
}