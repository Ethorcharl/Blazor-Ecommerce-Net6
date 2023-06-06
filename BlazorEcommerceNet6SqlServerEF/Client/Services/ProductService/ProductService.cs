using System.Net.Http.Json;

namespace BlazorEcommerceNet6SqlServerEF.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();

        public event Action ProductsChanged;

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}"); //$ for parametr
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/getprod") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}"); //category/{categoryUrl}"
            //var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/getprod");
            //if (categoryUrl == null)
            //{
            //     result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/getprod");
            //}
            //else {
            //     result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
            //}

            if (result != null && result.Data != null)
                Products = result.Data;

           ProductsChanged.Invoke();
        }

    }
}
