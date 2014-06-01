namespace ToBeImplemented.Business.Interfaces
{
    using ToBeImplemented.Domain.ViewModel;
    using ToBeImplemented.Domain.ViewModel.Users;

    public interface IUsersLogic
    {
        RegisterUserViewModel GetRegisterViewModel();
        UserViewModel RegisterUser(RegisterUserViewModel model);
    }
}