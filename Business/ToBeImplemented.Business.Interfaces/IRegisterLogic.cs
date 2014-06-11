namespace ToBeImplemented.Business.Interfaces
{
    using ToBeImplemented.Business.Interfaces.Common;
    using ToBeImplemented.Domain.ViewModel.Users;

    public interface IRegisterLogic
    {
        BussinesResult<RegisterUserViewModel> GetRegisterViewModel();
        BussinesResult<long> RegisterUser(RegisterUserViewModel model);
    }
}