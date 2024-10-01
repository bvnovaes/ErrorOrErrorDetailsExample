using ErrorDetailsExample.Domain.Users;
using ErrorDetailsExample.Domain.Users.Services;
using ErrorDetailsExample.Infrastructure.Repositories;
using ErrorOr;

namespace ErrorDetailsExample.Application.Users.Services;

public class GetAllAllUsersService(IUserRepository userRepository) : IGetAllUsersService
{
    public ErrorOr<List<User>> GetAllUsers()
    {
        return userRepository.GetAllUsers();
    }
}