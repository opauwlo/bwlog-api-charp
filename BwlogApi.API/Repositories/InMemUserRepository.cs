namespace BwlogApi.API.Repositories;
using BwlogApi.API.Models;

public class InMemUserRepository : IUserRepository
{

    private readonly List<User> users = new()
    {
        new User { Id = Guid.NewGuid(), Username = "admin1", Bio = "admin1", Password = "admin1", Email = "email@email", ProfileImgUrl = "profileImgUrl", CoverImgUrl = "coverImgUrl", ProfileImgId = "profileImgId", CoverImgId = "coverImgId", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
        new User { Id = Guid.NewGuid(), Username = "admin", Bio = "admin", Password = "admin", Email = "email@email", ProfileImgUrl = "profileImgUrl", CoverImgUrl = "coverImgUrl", ProfileImgId = "profileImgId", CoverImgId = "coverImgId", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
    };

    public List<User> GetUsers() => this.users;

    public User GetUserById(Guid id) => this.users.SingleOrDefault(user => user.Id == id);

    public void CreateUser(User user) => this.users.Add(user);
    public void UpdateUser(User user)
    {
        var index = this.users.FindIndex(existingUser => existingUser.Id == user.Id);
        this.users[index] = user;
    }
}
