using Stock.Commands;
using Stock.Models;
using System.Threading.Tasks;

namespace Stock.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateUserCommand command);
        Task<UserModel> AuthenticateAsync(string email, string password);
    }
}
