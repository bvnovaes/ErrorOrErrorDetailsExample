using AutoMapper;
using ErrorDetailsExample.Contracts.Requests;
using ErrorDetailsExample.Contracts.Responses;
using ErrorDetailsExample.Domain.Users;
using ErrorDetailsExample.Domain.Users.Services;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ErrorDetailsExample.Api.Controllers;

[Route("[controller]")]
public class UsersController(
    IGetAllUsersService getAllUsersService,
    IGetUserByIdService getUserByIdService,
    ICreateUserService createUserService,
    IUpdateUserService updateUserService,
    IDeleteUserService deleteUserService,
    IMapper mapper,
    IValidator<CreateUserRequest> createUserRequestValidator,
    IValidator<UpdateUserRequest> updateUserRequestValidator) : ApiController
{
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        ErrorOr<List<User>> result = getAllUsersService.GetAllUsers();

        return result.Match(
            success => Ok(mapper.Map<List<UserResponse>>(success)),
            Problem);

        //return result.IsError
        //    ? Problem(result.Errors)
        //    : Ok(result.Value);
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        ValidationResult? validationResult = createUserRequestValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            List<Error> errors = validationResult.Errors
                .Select(e => Error.Validation(e.PropertyName, e.ErrorMessage))
                .ToList();

            return Problem(errors);
        }

        var user = mapper.Map<User>(request);
        ErrorOr<User> result = createUserService.CreateUser(user);

        return result.Match(
            success => CreatedAtAction(nameof(CreateUser), new { id = success.Id }, mapper.Map<UserResponse>(success)),
            Problem);

        //return result.IsError
        //    ? Problem(result.Errors)
        //    : CreatedAtAction(nameof(CreateUser), new { id = result.Value.Id }, mapper.Map<UserResponse>(result.Value));
    }

    [HttpGet("{id:long}")]
    public IActionResult GetUserById(long id)
    {
        ErrorOr<User> result = getUserByIdService.GetUserById(id);

        return result.Match(
            success => Ok(mapper.Map<UserResponse>(success)),
            Problem);

        //return result.IsError
        //    ? Problem(result.Errors)
        //    : Ok(mapper.Map<UserResponse>(result.Value));
    }

    [HttpPut("{id:long}")]
    public ActionResult<UserResponse> UpdateUser(long id, UpdateUserRequest request)
    {
        ValidationResult? validationResult = updateUserRequestValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            List<Error> errors = validationResult.Errors
                .Select(e => Error.Validation(e.PropertyName, e.ErrorMessage))
                .ToList();

            return Problem(errors);
        }

        User user = mapper.Map<User>(request) with { Id = id };
        ErrorOr<User> result = updateUserService.UpdateUser(user);

        return result.Match(
            success => Ok(mapper.Map<UserResponse>(success)),
            Problem);

        //return result.IsError
        //    ? Problem(result.Errors)
        //    : Ok(result.Value);
    }

    [HttpDelete("{id:long}")]
    public ActionResult DeleteUser(long id)
    {
        ErrorOr<User> result = deleteUserService.DeleteUser(id);

        return result.Match(
            _ => NoContent(),
            Problem);

        //return result.IsError
        //    ? Problem(result.Errors)
        //    : NoContent();
    }
}
