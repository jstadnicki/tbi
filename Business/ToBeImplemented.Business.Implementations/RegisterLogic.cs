namespace ToBeImplemented.Business.Implementations
{
    using AutoMapper;

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
        private readonly IUserPasswordHasher userPasswordHasher;

        public RegisterLogic(
            ISecurityChallengeProvider securityChallengeProvider,
            IRegisterService registerService,
            IDateTimeAdapter dateTimeAdapter,
            IUserPasswordHasher userPasswordHasher)
        {
            this.securityChallengeProvider = securityChallengeProvider;
            this.registerService = registerService;
            this.dateTimeAdapter = dateTimeAdapter;
            this.userPasswordHasher = userPasswordHasher;
        }

        public OperationResult<RegisterUserViewModel> GetRegisterViewModel()
        {
            var result = new RegisterUserViewModel();
            result.ChallengeType = this.securityChallengeProvider.GetChallengeType();
            result.SecurityChallengeText = this.securityChallengeProvider.GetChallengeInput();
            return new OperationResult<RegisterUserViewModel>(result);
        }

        public OperationResult<long> RegisterUser(RegisterUserViewModel model)
        {
            var securityValidationResult = this.securityChallengeProvider.IsChallengeValid(
                model.SecurityChallengeText,
                model.SecurityResult,
                model.ChallengeType);


            OperationResult<long> result = null;

            if (securityValidationResult)
            {
                var now = this.dateTimeAdapter.Now;
                var registerUserModel = Mapper.Map<RegisterUser>(model);

                registerUserModel.PasswordHash = this.userPasswordHasher.GetHash(
                    model.Password,
                    now.ToFileTime().ToString());
                registerUserModel.RegisterDateTime = now;
                var registeredUserId = this.registerService.RegisterUser(registerUserModel);
                result = new OperationResult<long>(registeredUserId);
            }
            else
            {
                result = new OperationResult<long>(-1, false, "--- security challenge failed ---");
            }

            return result;

        }
    }
}