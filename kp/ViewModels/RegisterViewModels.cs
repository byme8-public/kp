using kp.ViewModels.Login;
using kp.ViewModels.UserRoles;
using kp.ViewModels.Users;
using Microsoft.Extensions.DependencyInjection;

namespace kp.ViewModels
{
    public static class RegisterViewModels
    {
        public static void AddViewModels(this IServiceCollection servoces)
        {
            servoces.AddScoped<UsersListViewModel>();
            servoces.AddScoped<NewUserViewModel>();
            servoces.AddScoped<EditUserViewModel>();
            servoces.AddScoped<UserRolesViewModel>();
            servoces.AddScoped<NewUserRoleViewModel>();
            servoces.AddScoped<MainViewModel>();
            servoces.AddScoped<LoginViewModel>();
        }
    }
}