using System.Security.Claims;
using MoneyManager.Contracts.Account;
using MoneyManager.Contracts.Enums;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Interfaces;
using MoneyManager.Domain.Responses;
using MoneyManager.Services.Interfaces;

namespace MoneyManager.Services.Implementations;

public class AccountService : IAccountService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AccountService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<IBaseResponse<bool>> Registration(RegisterViewModel model)
    {
        try
        {
            var userExists = await _userRepository.GetUserByEmail(model.Email);

            if (userExists != null)
            {
                return new BaseResponse<bool>()
                {
                    Message = "This category already exists",
                    StatusCode = StatusCode.BadRequestError,
                };
            }

            var user = new User
            {
                Username = model.UserName,
                Email = model.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password)
            };

            await _userRepository.Create(user);

            return new BaseResponse<bool>()
            {
                StatusCode = StatusCode.OK,
                Message = "User has registered successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Message = $"[Registration] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<string>> Login(LoginViewModel model)
    {
        try
        {
            var user = await _userRepository.GetUserByEmail(model.Email);

            if (user == null)
            {
                return new BaseResponse<string>()
                {
                    Message = "This category already exists",
                    StatusCode = StatusCode.UserNotFound,
                };
            }

            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return new BaseResponse<string>()
                {
                    Message = "Invalid credentials",
                    StatusCode = StatusCode.UserNotFound,
                };
            }

            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            
            return new BaseResponse<string>()
            {
                Message = await accessToken,
                StatusCode = StatusCode.OK,
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<string>()
            {
                Message = $"[Login] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}