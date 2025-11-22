using Shop.Auth.Data.Context;
using Shop.Auth.Repositories.Interfaces;

namespace Shop.Auth.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private RepositoryUser _repositoryUser;
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IRepositoryUser RepositoryUser
    {
        get
        {
            return _repositoryUser = _repositoryUser ?? new RepositoryUser(_context);
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}