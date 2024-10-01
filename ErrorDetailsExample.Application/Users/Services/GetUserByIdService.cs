using ErrorDetailsExample.Domain.Users;
using ErrorDetailsExample.Domain.Users.Services;
using ErrorDetailsExample.Infrastructure.Repositories;
using ErrorOr;

namespace ErrorDetailsExample.Application.Users.Services;

public class GetUserByIdService(IUserRepository userRepository) : IGetUserByIdService
{
    public ErrorOr<User> GetUserById(long id)
    {
        return userRepository.GetUserById(id);
    }
}