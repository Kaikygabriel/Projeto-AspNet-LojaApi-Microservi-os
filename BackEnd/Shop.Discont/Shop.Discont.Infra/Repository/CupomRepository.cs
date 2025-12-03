using System.Linq.Expressions;
using Dapper;
using DapperExtensions;
using Microsoft.Data.SqlClient;
using Shop.Discont.Domain.BackOffice.Entitites;
using Shop.Discont.Domain.BackOffice.Interfaces;
using Shop.Discont.Infra.Data.Contracts;

namespace Shop.Discont.Infra.Repository;

public class CupomRepository : IRepositoryCupom
{
    private readonly SqlConnection _sqlConnection;

    public CupomRepository(ISqlConnection connection)
    {
        _sqlConnection = connection.CreateSqlConnection();
    }


    public async Task<IEnumerable<Cupom>> GetAllAsync()
    {
        var query = "SELECT * FROM [Cupom]";
        return await _sqlConnection.QueryAsync<Cupom>(query);
    }

    public async Task<Cupom?> GetByPredicate(Expression<Func<Cupom, bool>> predicate)
    {
        return await _sqlConnection.GetAsync<Cupom>(predicate);
    }

    public async Task Create(Cupom entity)
    {
        if (entity is null)
            return;
        var query = "INSERT INTO [Cupom]([Nome],[Desconto]) VALUES (@Nome,@Desconto)"; 
        await _sqlConnection.ExecuteAsync(query, new
        {
            Nome = entity.Name,
            Desconto = entity.Descont
        });
    }

    public async Task Update(Cupom entity)
    {
        if (entity is null)
            return;
        var query = @"UPDATE [Cupom] SET [Nome] = @Nome, [Desconto] = @Desconto WHERE [Id] = @Id";
        await _sqlConnection.ExecuteAsync(query, new
        {
            Nome = entity.Name,
            Desconto = entity.Descont,
            Id = entity.Id
        });
    }

    public async Task Delete(Cupom entity)
    {
        if (entity is null)
            return;
        var query = @"DELETE FROM [Cupom] WHERE [Id] = @Id";
        await _sqlConnection.ExecuteAsync(query, new
        {
            Id = entity.Id
        });
    }
}