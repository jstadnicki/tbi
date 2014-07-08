namespace ToBeImplemented.Business.Interfaces
{
    using ToBeImplemented.Business.ViewModel.Users;
    using ToBeImplemented.Common.Data;

    public interface IRegisterLogic
    {
        OperationResult<RegisterUserViewModel> GetRegisterViewModel();
        OperationResult<long> RegisterUser(RegisterUserViewModel model);
    }
}