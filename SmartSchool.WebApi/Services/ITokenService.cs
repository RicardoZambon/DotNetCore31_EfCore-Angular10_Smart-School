namespace SmartSchool.WebApi.Services
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}