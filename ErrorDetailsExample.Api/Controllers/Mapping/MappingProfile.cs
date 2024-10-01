using AutoMapper;
using ErrorDetailsExample.Contracts.Requests;
using ErrorDetailsExample.Contracts.Responses;
using ErrorDetailsExample.Domain.Users;

namespace ErrorDetailsExample.Api.Controllers.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserResponse>();
        CreateMap<CreateUserRequest, User>();
        CreateMap<UpdateUserRequest, User>();
    }
}