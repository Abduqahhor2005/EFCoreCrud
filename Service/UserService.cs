using EFCoreCrud.DataContext;
using EFCoreCrud.Entity;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace EFCoreCrud.Service;

public class UserService(ApplicationContext appContext) : IUserService
{
    public async Task<IEnumerable<User>> GetAll()
    {
        try
        {
            return await appContext.Users.ToListAsync();
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<User?> GetById(int id)
    {
        try
        {
            return await appContext.Users.FindAsync(id);
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> Create(User user)
    {
        try
        {
            appContext.Users.Add(user);
            return await appContext.SaveChangesAsync() > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> Update(User user)
    {
        try
        {
            User? user1 = await appContext.Users.FindAsync(user.Id);
            if (user1 == null) return false;
            user1.Name = user.Name;
            user1.Age = user.Age;
            return await appContext.SaveChangesAsync() > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            User? user = await appContext.Users.FindAsync(id);
            if (user == null) return false;
            appContext.Users.Remove(user);
            return await appContext.SaveChangesAsync() > 0;
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}