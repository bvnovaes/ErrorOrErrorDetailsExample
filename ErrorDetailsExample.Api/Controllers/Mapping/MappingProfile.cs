using AutoMapper;
using ErrorDetailsExample.Contracts.Requests;
using ErrorDetailsExample.Contracts.Responses;
using ErrorDetailsExample.Domain.Users;

namespace ErrorDetailsExample.Api.Controllers.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserResponse, User>().ReverseMap();
        CreateMap<CreateUserRequest, User>().ReverseMap();
        CreateMap<UpdateUserRequest, User>().ReverseMap();
    }
}
