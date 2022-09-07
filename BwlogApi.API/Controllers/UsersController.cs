namespace BwlogApi.API.Controllers;

using BwlogApi.API.DTOs;
using BwlogApi.API.Models;
using BwlogApi.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUserRepository userRepository;
    public UsersController(ILogger<UsersController> logger, IUserRepository userRepository)
    {
        this._logger = logger;
        this.userRepository = userRepository;
    }

    [HttpGet("users")]
    [SwaggerOperation(Tags = new[] { "Get Users" })]
    [SwaggerResponse(200, "Returns the list of users", typeof(List<UserDTO>))]
    public IEnumerable<UserDTO> GetUsers()
    {
        var users = this.userRepository.GetUsers().Select(user => user.AsDto());
        return users;
    }
    [HttpGet("user/{id}")]
    [SwaggerOperation(Tags = new[] { "Get User By Id" })]
    [SwaggerResponse(200, "User found", typeof(UserDTO))]
    public ActionResult<UserDTO> GetUserById(Guid id)
    {
        var user = this.userRepository.GetUserById(id);

        if (user is null)
        {
            return this.NotFound();
        }

        return user.AsDto();
    }

    [HttpPost("new/user")]
    [SwaggerOperation(Tags = new[] { "Create User" })]
    [SwaggerResponse(201, "User created", typeof(UserDTO))]
    public ActionResult<UserDTO> CreateUser(CreateUserDTO userDTO)
    {
        User user = new()
        {
            Id = Guid.NewGuid(),
            Username = userDTO.Username,
            Password = userDTO.Password,
            Email = userDTO.Email,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        this.userRepository.CreateUser(user);

        return this.CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user.AsDto());
    }

    [HttpPut("update/user/{id}")]
    [SwaggerOperation()]
    [SwaggerResponse(204, "User updated")]
    public ActionResult<UserDTO> UpdateUser(Guid id, UpdateUserDTO userDTO)
    {
        var existingUser = this.userRepository.GetUserById(id);

        if (existingUser is null)
        {
            return this.NotFound();
        }

        var updatedUser = existingUser with
        {
            Username = userDTO.Username ?? existingUser.Username,
            Bio = userDTO.Bio ?? existingUser.Bio,
            ProfileImgUrl = userDTO.ProfileImgUrl ?? existingUser.ProfileImgUrl,
            CoverImgUrl = userDTO.CoverImgUrl ?? existingUser.CoverImgUrl,
            ProfileImgId = userDTO.ProfileImgId ?? existingUser.ProfileImgId,
            CoverImgId = userDTO.CoverImgId ?? existingUser.CoverImgId,
            UpdatedAt = DateTime.UtcNow
        };

        this.userRepository.UpdateUser(updatedUser);

        return this.NoContent();

    }
}
