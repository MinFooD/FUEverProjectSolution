using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddBusinessLogicLayer(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddAutoMapper(applicationAssembly);
        services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IPetsService, PetsService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IStoreService, StoreService>();   
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IManageEmployeeService, ManageEmployeeService>();
	}
}