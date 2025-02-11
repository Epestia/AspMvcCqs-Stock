using Stock.Models;
using System.Threading.Tasks;

namespace Stock.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(UserModel user);
        Task<UserModel> GetUserByEmailAsync(string email);
    }
}
