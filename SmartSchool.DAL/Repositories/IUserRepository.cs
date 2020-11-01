using SmartSchool.DAL.DatabaseObjects;
using System.Threading.Tasks;

namespace SmartSchool.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AuthenticateAsync(long userId, string passwordHash);

        Task<User> FindByUsernameAsync(string username);
    }
}