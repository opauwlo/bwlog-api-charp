namespace BwlogApi.API;

using BwlogApi.API.DTOs;
using BwlogApi.API.Models;
public static class Extensions
{
    public static UserDTO AsDto(this User user) => new()
    {
        Id = user.Id,
        Username = user.Username,
        Bio = user.Bio,
        Password = user.Password,
        Email = user.Email,
        ProfileImgUrl = user.ProfileImgUrl,
        CoverImgUrl = user.CoverImgUrl,
        ProfileImgId = user.ProfileImgId,
        CoverImgId = user.CoverImgId,
        CreatedAt = user.CreatedAt,
        UpdatedAt = user.UpdatedAt
    };
}
