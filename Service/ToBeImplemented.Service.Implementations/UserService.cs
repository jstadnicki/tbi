namespace ToBeImplemented.Service.Implementations
{
    using ToBeImplemented.Domain.Model;
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

        public User RegisterUser(RegisterUser registerUser)
        {
            var id = this.userRepository.RegisterUser(registerUser);
            var result = this.userRepository.GetUser(id);
            return result;
        }
    }
}