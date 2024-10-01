using ErrorDetailsExample.Application.Users.Services;
using ErrorDetailsExample.Application.Users.Validators;
using ErrorDetailsExample.Contracts.Requests;
using ErrorDetailsExample.Domain.Users.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorDetailsExample.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGetAllUsersService, GetAllAllUsersService>();
        services.AddScoped<IGetUserByIdService, GetUserByIdService>();
        services.AddScoped<ICreateUserService, CreateUserService>();
        services.AddScoped<IUpdateUserService, UpdateUserService>();
        services.AddScoped<IDeleteUserService, DeleteUserService>();

        services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
        services.AddScoped<IValidator<UpdateUserRequest>, UpdateUserRequestValidator>();
        
        return services;
    }
}