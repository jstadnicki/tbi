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

        public UserViewModel RegisterUser(RegisterUserViewModel model)
        {
            var securityValidationResult = this.securityChallengeProvider.IsChallengeValid(
                model.SecurityChallengeText,
                model.SecurityResult,
                model.ChallengeType);

            UserViewModel result = null;
            if (securityValidationResult == true)
            {
                var registerUserModel = Mapper.Map<RegisterUser>(model);
                var userModel = this.userService.RegisterUser(registerUserModel);

                result = Mapper.Map<UserViewModel>(userModel);
            }

            return result;

        }
    }
}