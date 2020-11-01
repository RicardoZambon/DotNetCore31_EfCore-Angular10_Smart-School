using SmartSchool.WebApi.Models;

namespace SmartSchool.WebApi.Services
{
    public interface IUserService
    {
        bool AuthenticateAndGenerateToken(UserLoginModel model, out string token);
    }
}