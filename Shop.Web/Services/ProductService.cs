using System.Text.Json;
using Shop.Web.Models;
using Shop.Web.Services.Interfaces;

namespace Shop.Web.Services;

public class ProductService : IProductService
{
    private const string EndPointAPi = "/Products";
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    
    public ProductService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public Task<IEnumerable<ProductViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductViewModel> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public bool Create(ProductViewModel product)
    {
        throw new NotImplementedException();
    }

    public bool Delete(string name)
    {
        throw new NotImplementedException();
    }
}