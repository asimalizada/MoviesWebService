using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Security.Jwt;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<User> Login(UserLoginDto userLoginDto)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<User> Register(UserRegisterDto userRegisterDto)
        {
            throw new System.NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            if (this._userService.GetByEmail(email) != null)
                return new ErrorResult("User already exists");

            return new SuccessResult();
        }
    }
}
