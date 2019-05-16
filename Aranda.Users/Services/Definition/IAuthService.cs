using Aranda.Users.BackEnd.Dtos;

namespace Aranda.Users.BackEnd.Services.Definition
{
    public interface IAuthService
    {
        UserDataDto Authenticate(string userName, string password);
    }
}
