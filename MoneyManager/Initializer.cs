using MoneyManager.Domain.Interfaces;
using MoneyManager.Persistence.Repositories;

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
    }
}