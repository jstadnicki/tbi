namespace ToBeImplemented.Business.Implementations
{
    using AutoMapper;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Domain.ViewModel.Users;
    using ToBeImplemented.Service.Interfaces;

    public class UsersLogic : IUsersLogic
    {
        private readonly ISecurityChallengeProvider securityChallengeProvider;

        private readonly IUserService userService;

        public UsersLogic(ISecurityChallengeProvider securityChallengeProvider, IUserService userService)
        {
            this.securityChallengeProvider = securityChallengeProvider;
            this.userService = userService;
        }

        public RegisterUserViewModel GetRegisterViewModel()
        {
            var result = new RegisterUserViewModel();
            result.ChallengeType = this.securityChallengeProvider.GetChallengeType();
            result.SecurityChallengeText = this.securityChallengeProvider.GetChallengeInput();
            return result;
        }

        public long RegisterUser(RegisterUserViewModel model)
        {
            var securityValidationResult = this.securityChallengeProvider.IsChallengeValid(
                model.SecurityChallengeText,
                model.SecurityResult,
                model.ChallengeType);

            long result = 0;
            if (securityValidationResult)
            {
                var registerUserModel = Mapper.Map<RegisterUser>(model);
                result = this.userService.RegisterUser(registerUserModel);
            }

            return result;

        }
    }
}