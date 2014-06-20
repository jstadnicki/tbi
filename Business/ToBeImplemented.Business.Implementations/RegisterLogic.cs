namespace ToBeImplemented.Business.Implementations
{
    using AutoMapper;

    using Microsoft.AspNet.Identity;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Common.Data;
    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Domain.ViewModel.Users;
    using ToBeImplemented.Infrastructure.Interfaces.Adapters;
    using ToBeImplemented.Service.Interfaces;

    public class RegisterLogic : IRegisterLogic
    {
        private readonly ISecurityChallengeProvider securityChallengeProvider;
        private readonly IRegisterService registerService;
        private readonly IDateTimeAdapter dateTimeAdapter;

        private readonly IUserPasswordStore<User, long> userStore;

        public RegisterLogic(
            ISecurityChallengeProvider securityChallengeProvider,
            IRegisterService registerService,
            IDateTimeAdapter dateTimeAdapter)
        {
            this.securityChallengeProvider = securityChallengeProvider;
            this.registerService = registerService;
            this.dateTimeAdapter = dateTimeAdapter;
            this.userStore = userStore;
        }

        public OperationResult<RegisterUserViewModel> GetRegisterViewModel()
        {
            var result = new RegisterUserViewModel();
            result.ChallengeType = this.securityChallengeProvider.GetChallengeType();
            result.SecurityChallengeText = this.securityChallengeProvider.GetChallengeInput();
            return new OperationResult<RegisterUserViewModel>(result);
        }

        public OperationResult<long> RegisterUser(RegisterUserViewModel viewModel)
        {
            var securityResult = this.securityChallengeProvider.IsChallengeValid(
                viewModel.SecurityChallengeText,
                viewModel.SecurityResult,
                viewModel.ChallengeType);

            if (securityResult == true)
            {
                var rm = Mapper.Map<RegisterUser>(viewModel);
                rm.RegisterDateTime = this.dateTimeAdapter.Now;
                var result = this.registerService.RegisterUser(rm);
                return new OperationResult<long>(result);
            }
            else
            {
                return new OperationResult<long>(-1, false, "--- security challenge failed ---");
            }
        }
    }
}