using EFCoreCrud.Entity;

namespace EFCoreCrud.Service;

public interface IUserService
{
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(int id);
    Task<bool> Create(User user);
    Task<bool> Update(User user);
    Task<bool> Delete(int id);
}