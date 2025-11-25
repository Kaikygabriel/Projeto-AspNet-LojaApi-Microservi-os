using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Shop.Web.Products.Interfaces;
using Shop.Web.Products.Models;

namespace Shop.Web.Products.Services;

public class ProductService : IProductService
{
    private const string ClientProduct = "ProductApi";
    private const string EndPointAPi = "products";
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    
    public ProductService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<IEnumerable<ProductViewModel>?> GetAllAsync()
    {
        var Products = new List<ProductViewModel>();
        var client = _clientFactory.CreateClient(ClientProduct);
        using var response = await client.GetAsync(EndPointAPi);
        if (!response.IsSuccessStatusCode)
            return null;
            
        var content = await response.Content.ReadAsStreamAsync();
        return  JsonSerializer.Deserialize<List<ProductViewModel>>
            (content, _jsonSerializerOptions);
    }

    public async Task<ProductViewModel?> GetById(int id)
    {
        var client = _clientFactory.CreateClient(ClientProduct);

        using var response = await client.GetAsync($"{EndPointAPi}/{id}");
        if (!response.IsSuccessStatusCode)
            return null;
        var content =await response.Content.ReadAsStreamAsync();
        return JsonSerializer.Deserialize<ProductViewModel>
            (content, _jsonSerializerOptions);
    }

    public async Task<bool> Create(ProductViewModel product,string token)
    {
        try
        {
            var client = CreateHttpClientProduct( token);
            var Request = JsonSerializer.Serialize(product, _jsonSerializerOptions);
            var content = new StringContent(Request,Encoding.UTF8,"Application/json");
            using var response = await client.PostAsync(EndPointAPi,content);
            if (!response.IsSuccessStatusCode)
                return false; 
            
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Delete(int id,string token)
    {
        try
        {
            var client = CreateHttpClientProduct( token);
            using var response = await client.DeleteAsync($"{EndPointAPi}/{id}");
            if (!response.IsSuccessStatusCode)
                return false; 
            
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private HttpClient CreateHttpClientProduct(string token)
    {
        var client = _clientFactory.CreateClient(ClientProduct);
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer",token);
        return client;
    }
}