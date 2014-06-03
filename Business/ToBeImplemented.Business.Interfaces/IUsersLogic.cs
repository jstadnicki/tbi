namespace ToBeImplemented.Business.Interfaces
{
    using ToBeImplemented.Domain.ViewModel.Users;

    public interface IUsersLogic
    {
        RegisterUserViewModel GetRegisterViewModel();
        long RegisterUser(RegisterUserViewModel model);
    }
}