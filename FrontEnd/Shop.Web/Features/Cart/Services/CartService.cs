using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Shop.Web.Cart.Models;

namespace Shop.Web.Cart.Services;

public class CartService
{
    private const string ClientCart = "CartApi";
    private const string EndPointAPi = "Cart";
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    
    public CartService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<bool> CreateCart(Models.Cart cart,string token)
    {
        var client = CreateHttpClientCart(token);
        var jsonCart = JsonSerializer.Serialize(cart);
        var requestBody = new StringContent(jsonCart,Encoding.UTF8,"application/json");
        using var response = await client.PostAsync(EndPointAPi, requestBody);
        if (!response.IsSuccessStatusCode)
            return false;
        
        return true;
    }
    public async Task<bool> AddItem(CartItem item, string idUser,string token)
    {
        var client = CreateHttpClientCart(token);
        var jsonCartItem = JsonSerializer.Serialize(item);
        var requestBody = new StringContent(jsonCartItem,Encoding.UTF8,"application/json");
        using var response = await client.PostAsync($"{EndPointAPi}/AddItemInCart?id={idUser}", requestBody);
        if (!response.IsSuccessStatusCode)
            return false;
        
        return true;
    }

    public async Task<Models.Cart> GetCartByIdOrNull(int Id, string token)
    {
        var client = CreateHttpClientCart(token);
        using var response = await client.GetAsync($"{EndPointAPi}/GetById?Id={Id}");
        if (!response.IsSuccessStatusCode)
            return null;
        var content = await response.Content.ReadAsStreamAsync();
        var cart = JsonSerializer.Deserialize<Models.Cart>(content,_jsonSerializerOptions);
        return cart;
    }
    
    public async Task<IEnumerable<CartItem>> GetCartItemByUserIdOrNull(string userId, string token)
    {
        var client = CreateHttpClientCart(token);
        using var response = await client.GetAsync($"{EndPointAPi}/GetByUserId?Id={userId}");
        if (!response.IsSuccessStatusCode)
            return null;
        var content = await response.Content.ReadAsStreamAsync();
        var cart = JsonSerializer.Deserialize<IEnumerable<CartItem>>(content,_jsonSerializerOptions);
        return cart;
    }
    
    private HttpClient CreateHttpClientCart(string token)
    {
        var client = _clientFactory.CreateClient(ClientCart);
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer",token);
        return client;
    }
}