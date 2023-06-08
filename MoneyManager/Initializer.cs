using MoneyManager.Domain.Interfaces;
using MoneyManager.Persistence.Repositories;
using MoneyManager.Services.Implementations;
using MoneyManager.Services.Interfaces;

namespace MoneyManager;

public static class Initializer
{
    public static void InitializeRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
    }

    public static void InitializeServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAccountService, AccountService>();
    }
}