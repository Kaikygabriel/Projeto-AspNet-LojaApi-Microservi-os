using System.Linq.Expressions;
using Shop.Discont.Domain.BackOffice.Entitites;
using Shop.Discont.Domain.BackOffice.Interfaces;

namespace Shop.Discont.Test.Mock;

public class FakeCupomRepository : IRepositoryCupom
{
    private readonly List<Cupom> _cupons = new();

    public FakeCupomRepository()
    {
        // Dados iniciais de mock
        _cupons.Add(new Cupom("Desconto10", 10));
        _cupons.Add(new Cupom("Promo20", 20));
        _cupons.Add(new Cupom("Cupom5", 5));
    }

    public Task<IEnumerable<Cupom>> GetAllAsync()
    {
        return Task.FromResult(_cupons.AsEnumerable());
    }

    public Task<Cupom?> GetByPredicate(Expression<Func<Cupom, bool>> predicate)
    {
        var compiled = predicate.Compile();
        var result = _cupons.FirstOrDefault(compiled);
        return Task.FromResult(result);
    }

    public Task Create(Cupom entity)
    {
        _cupons.Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(Cupom entity)
    {
        var index = _cupons.FindIndex(x => x.Id == entity.Id);

        if (index >= 0)
        {
            _cupons[index] = entity;
        }

        return Task.CompletedTask;
    }

    public Task Delete(Cupom entity)
    {
        _cupons.Remove(entity);
        return Task.CompletedTask;
    }
}