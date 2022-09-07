namespace BwlogApi.API.Models;

public record User
{
    public Guid Id { get; init; }
    public string Username { get; set; }
    public string Bio { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string ProfileImgUrl { get; set; }
    public string CoverImgUrl { get; set; }
    public string ProfileImgId { get; set; }
    public string CoverImgId { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}
