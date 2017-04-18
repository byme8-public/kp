using kp.ViewModels.Clients;
using kp.ViewModels.Login;
using kp.ViewModels.PaymentsKinds;
using kp.ViewModels.UserRoles;
using kp.ViewModels.Users;
using Microsoft.Extensions.DependencyInjection;

namespace kp.ViewModels
{
    public static class RegisterViewModels
    {
        public static void AddViewModels(this IServiceCollection servoces)
        {
            servoces.AddTransient<MainViewModel>();
            servoces.AddTransient<LoginViewModel>();
            servoces.AddTransient<ClientsViewModel>();
            servoces.AddTransient<NewUserViewModel>();
            servoces.AddTransient<EditUserViewModel>();
            servoces.AddTransient<UserRolesViewModel>();
            servoces.AddTransient<UsersListViewModel>();
            servoces.AddTransient<NewClientViewModel>();
            servoces.AddTransient<MainWindowViewModel>();
            servoces.AddTransient<EditClientViewModel>();
            servoces.AddTransient<NewUserRoleViewModel>();
            servoces.AddTransient<PaymentsKindViewModel>();
            servoces.AddTransient<NewPaymentKindViewModel>();
            servoces.AddTransient<EditPaymentKindViewModel>();
            servoces.AddTransient<UserRolesManagmentViewModel>();
        }
    }
}