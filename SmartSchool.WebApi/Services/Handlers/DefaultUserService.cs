using SmartSchool.DAL.DatabaseObjects;
using SmartSchool.DAL.Repositories;
using SmartSchool.DAL.Security;
using SmartSchool.WebApi.Models;

namespace SmartSchool.WebApi.Services.Handlers
{
    public class DefaultUserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;

        public DefaultUserService(IUserRepository userRepository, ITokenService tokenService)
        {
            this.userRepository = userRepository;
            this.tokenService = tokenService;
        }


        public virtual bool AuthenticateAndGenerateToken(UserLoginModel model, out string token)
        {
            if (userRepository.FindByUsernameAsync(model.Username).Result is User user
                && userRepository.AuthenticateAsync(user.Id, PasswordHash.Create(user.Id, model.Password)).Result)
            {
                token = tokenService.GenerateToken(model.Username);
                return true;
            }
            token = null;
            return false;
        }
    }
}