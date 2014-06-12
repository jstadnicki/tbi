namespace ToBeImplemented.Business.Interfaces
{
    using ToBeImplemented.Common.Data;
    using ToBeImplemented.Domain.ViewModel.Users;

    public interface IRegisterLogic
    {
        OperationResult<RegisterUserViewModel> GetRegisterViewModel();
        OperationResult<long> RegisterUser(RegisterUserViewModel model);
    }
}