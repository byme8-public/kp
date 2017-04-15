using System.Collections.Generic;
using kp.Business.Entities;
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

        public List<UserRole> Roles
        {
            get;
            set;
        } = new List<UserRole>();
    }
}