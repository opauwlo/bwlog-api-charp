namespace BwlogApi.API.Repositories;
using System;
using BwlogApi.API.Models;
public interface IUserRepository
{
    List<User> GetUsers();
    User GetUserById(Guid id);
    void CreateUser(User user);
    void UpdateUser(User user);
}

