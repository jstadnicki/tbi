namespace ToBeImplemented.Business.Interfaces
{
    using ToBeImplemented.Business.Interfaces.Common;
    using ToBeImplemented.Domain.ViewModel.Users;

    public interface IUsersLogic
    {
        BussinesResult<RegisterUserViewModel> GetRegisterViewModel();
        BussinesResult<long> RegisterUser(RegisterUserViewModel model);
    }
}