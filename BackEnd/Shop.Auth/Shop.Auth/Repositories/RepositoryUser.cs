using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shop.Auth.Data.Context;
using Shop.Auth.Models;
using Shop.Auth.Repositories.Interfaces;

namespace Shop.Auth.Repositories;

public class RepositoryUser : IRepositoryUser
{
    private readonly AppDbContext _context;

    public RepositoryUser(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByPredicate(Expression<Func<User, bool>> predicate)
    {
        return await _context.Users.FirstOrDefaultAsync(predicate);
    }

    public void Create(User entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));
        _context.Users.Add(entity);
    }

    public void Update(User entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));
        _context.Users.Update(entity);
    }

    public void Delete(User entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));
        _context.Users.Remove(entity);
    }
}