using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Results.Abstract;
using Core.Security.Jwt;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserRegisterDto userRegisterDto, string password);
        IDataResult<User> Login(UserLoginDto userLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
