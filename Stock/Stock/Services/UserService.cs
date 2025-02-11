using Stock.Commands;
using Stock.Models;
using Stock.Repositories;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Stock.Services
{
    public class UserService : IUserService
    {
        private readonly CreateUserCommandHandler _commandHandler;
        private readonly IUserRepository _userRepository;

        public UserService(CreateUserCommandHandler commandHandler, IUserRepository userRepository)
        {
            _commandHandler = commandHandler;
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(CreateUserCommand command)
        {
            await _commandHandler.Handle(command);
        }



    public async Task<UserModel> AuthenticateAsync(string email, string password)
        {
        
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user == null)
            {
                return null;  
            }


            if (!BCrypt.Net.BCrypt.Verify(password, user.MotDePasse))
            {
                return null;  
            }

            return user;
        }

    }
}
