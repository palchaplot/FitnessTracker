using UserService.Models;
using Microsoft.EntityFrameworkCore;
namespace UserService.Repositories.Interfaces;



public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);

    Task<User?> GetByIdAsync(int id);

    Task AddUserAsync(User user);

    Task UpdateUserAsync(User user);

    Task DeleteUserAsync(User user);


}
