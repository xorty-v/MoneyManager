using MoneyManager.Contracts.Account;
using MoneyManager.Domain.Responses;

namespace MoneyManager.Services.Interfaces;

public interface IAccountService
{
    public Task<IBaseResponse<bool>> Registration(RegisterViewModel model);
    public Task<IBaseResponse<string>> Login(LoginViewModel model);
}