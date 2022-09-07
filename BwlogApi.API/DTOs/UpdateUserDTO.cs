namespace BwlogApi.API.DTOs;
public record UpdateUserDTO
{
    public string Username { get; set; }
    public string Bio { get; set; }
    public string ProfileImgUrl { get; set; }
    public string CoverImgUrl { get; set; }
    public string ProfileImgId { get; set; }
    public string CoverImgId { get; set; }

}
