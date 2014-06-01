namespace ToBeImplemented.Service.Implementations
{
    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Infrastructure.Interfaces;
    using ToBeImplemented.Service.Interfaces;

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
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