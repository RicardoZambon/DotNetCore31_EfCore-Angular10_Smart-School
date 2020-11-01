using Microsoft.EntityFrameworkCore;
using SmartSchool.DAL.DatabaseObjects;
using System.Threading.Tasks;

namespace SmartSchool.DAL.Repositories.EfCore
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context)
        {
            this.context = context;
        }


        public async Task<bool> AuthenticateAsync(long userId, string passwordHash)
            => await context.Set<User>().AnyAsync(x => x.Id == userId && x.PasswordHash == passwordHash);

        public async Task<User> FindByUsernameAsync(string username)
            => await context.Set<User>().FirstOrDefaultAsync(x => x.Username == username);
    }
}