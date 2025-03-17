using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<FueverDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IPetsRepository, PetsRepository>();
        services.AddScoped<IApplicationUsersRepository, ApplicationUsersRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
    }
}