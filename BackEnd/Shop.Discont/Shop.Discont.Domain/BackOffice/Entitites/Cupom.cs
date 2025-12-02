using System.ComponentModel;
using Shop.Discont.Domain.BackOffice.Entitites.Contracts;
using Shop.Discont.Domain.BackOffice.Exception;

namespace Shop.Discont.Domain.BackOffice.Entitites;

public class Cupom : Entity
{
    protected Cupom()
    {
        
    }
    public Cupom(string name, int descont)
    {
        if (!IsValid(name, descont))
            throw new CupomException();
        Name = name;
        Descont = descont;
    }

    public string Name { get;private set; }
    public int Descont { get;private set; }

    public bool IsValid(string name, int descont)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
            return false;
        if (descont >= 100 || descont <= 0)
            return false;
        return true;
    }
}