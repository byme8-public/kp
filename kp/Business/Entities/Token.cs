using kp.DataServies.Entities;
using kp.DataServies.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
