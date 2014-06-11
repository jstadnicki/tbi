namespace ToBeImplemented.Service.Implementations
{
    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Infrastructure.Interfaces;
    using ToBeImplemented.Service.Interfaces;

    public class RegisterService : IRegisterService
    {
        private readonly IUserRepository userRepository;

        public RegisterService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public long RegisterUser(RegisterUser registerUser)
        {
            var id = this.userRepository.RegisterUser(registerUser);
            return id;
        }
    }
}