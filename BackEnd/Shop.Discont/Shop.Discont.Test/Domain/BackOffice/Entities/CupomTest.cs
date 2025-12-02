using Shop.Discont.Domain.BackOffice.Entitites;
using Shop.Discont.Domain.BackOffice.Exception;

namespace Shop.Discont.Test.Domain.BackOffice.Entities;

public class CupomTest
{
    private const string NAME_VALID = "TESTE";
    private const string NAME_INVALID = "TE";
    private const string? NAME_NULL = null;
    
    private const int DISCONT_VALID = 20;
    private const int DISCONT_INVALID = -20;

    [Fact]
    public void CreateCupom_NameInvalid_DiscontInvalid_Return_Exception()
        => Assert.Throws<CupomException>(()
            => new Cupom(NAME_INVALID, DISCONT_INVALID));
    [Fact]
    public void CreateCupom_NameNull_DiscontValid_Return_Exception()
        => Assert.Throws<CupomException>(()
            => new Cupom(NAME_NULL, DISCONT_VALID));
    
    [Fact]
    public void CreateCupom_NameValid_DiscontValid_Return_NotNull()
    { 
        //arrange && act
        var cupom = new Cupom(NAME_VALID,DISCONT_VALID);
        //assert
        Assert.NotNull(cupom);
    }
}