namespace Shop.Auth.Repositories.Interfaces;

public interface IUnitOfWork 
{
    public IRepositoryUser RepositoryUser { get;}
    Task CommitAsync();
}