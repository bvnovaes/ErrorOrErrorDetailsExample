using ErrorOr;

namespace ErrorDetailsExample.Domain.Users.Services;

public interface IGetAllUsersService
{
    ErrorOr<List<User>> GetAllUsers();
}