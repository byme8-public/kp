using System;
using System.Threading.Tasks;
using kp.Business.Abstraction;
using kp.DataServies.Entities;
using WpfToolkit.Routing.Abstractions;

namespace kp.Business.Factories
{
    public class UserFactory : IEntityFactory<User>
    {
        public UserFactory(INavigator navigator)
        {
            this.Navigator = navigator;
        }

        public INavigator Navigator
        {
            get;
        }

        public Task<User> New()
        {
            this.Navigator.Navigate("users/new");
            throw new NotImplementedException();
        }
    }
}