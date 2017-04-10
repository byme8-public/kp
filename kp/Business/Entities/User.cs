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