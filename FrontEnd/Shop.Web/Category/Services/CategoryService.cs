using System.Text.Json;
using Shop.Web.Category.Interfaces;
using Shop.Web.Category.Models;

namespace Shop.Web.Category.Services;

public class CategoryService : ICategoryService
{
    private const string ClientEndPoint = "ProductApi";
    private const string ApiEndPoint = "Categorys";
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _optionsJson;
    
    public CategoryService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _optionsJson = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<IEnumerable<CategoryViewModel>?> GetAllAsync()
    {
        var client = _clientFactory.CreateClient(ClientEndPoint);
        using var response = await client.GetAsync(ApiEndPoint);
        if (!response.IsSuccessStatusCode)
            return null;
        var content =await response.Content.ReadAsStreamAsync();
        return JsonSerializer.Deserialize<IEnumerable<CategoryViewModel>>
            (content, _optionsJson);
    }
}