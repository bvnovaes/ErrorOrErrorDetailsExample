using ErrorOr;

namespace ErrorDetailsExample.Domain.Users.Services;

public interface IGetUserByIdService
{
    ErrorOr<User> GetUserById(long id);
}