namespace ToBeImplemented.Business.Implementations
{
    using AutoMapper;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Business.Interfaces.Common;
    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Domain.ViewModel.Users;
    using ToBeImplemented.Infrastructure.Interfaces.Adapters;
    using ToBeImplemented.Service.Interfaces;

    public class UsersLogic : IUsersLogic
    {
        private readonly ISecurityChallengeProvider securityChallengeProvider;
        private readonly IUserService userService;
        private readonly IDateTimeAdapter dateTimeAdapter;
        private readonly IUserPasswordHasher userPasswordHasher;

        public UsersLogic(
            ISecurityChallengeProvider securityChallengeProvider,
            IUserService userService,
            IDateTimeAdapter dateTimeAdapter,
            IUserPasswordHasher userPasswordHasher)
        {
            this.securityChallengeProvider = securityChallengeProvider;
            this.userService = userService;
            this.dateTimeAdapter = dateTimeAdapter;
            this.userPasswordHasher = userPasswordHasher;
        }

        public BussinesResult<RegisterUserViewModel> GetRegisterViewModel()
        {
            var result = new RegisterUserViewModel();
            result.ChallengeType = this.securityChallengeProvider.GetChallengeType();
            result.SecurityChallengeText = this.securityChallengeProvider.GetChallengeInput();
            return new BussinesResult<RegisterUserViewModel>(result);
        }

        public BussinesResult<long> RegisterUser(RegisterUserViewModel model)
        {
            var securityValidationResult = this.securityChallengeProvider.IsChallengeValid(
                model.SecurityChallengeText,
                model.SecurityResult,
                model.ChallengeType);


            BussinesResult<long> result = null;

            if (securityValidationResult)
            {
                var now = this.dateTimeAdapter.Now;
                var registerUserModel = Mapper.Map<RegisterUser>(model);

                registerUserModel.PasswordHash = this.userPasswordHasher.GetHash(
                    model.Password,
                    now.ToFileTime().ToString());
                registerUserModel.RegisterDateTime = now;
                var registeredUserId = this.userService.RegisterUser(registerUserModel);
                result = new BussinesResult<long>(registeredUserId);
            }
            else
            {
                result = new BussinesResult<long>(-1, false, "--- security challenge failed ---");
            }

            return result;

        }
    }
}