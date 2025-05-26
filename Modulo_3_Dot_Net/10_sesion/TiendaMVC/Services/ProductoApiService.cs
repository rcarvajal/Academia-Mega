using System.Net.Http.Json;
using TiendaMVC.Models;

namespace TiendaMVC.Services
{
    public class ProductoApiService : IProductoApiService
    {

        private readonly HttpClient _http;
        public ProductoApiService(HttpClient http) => _http = http;

        public async Task<List<Producto>> GetAllAsync() =>
            await _http.GetFromJsonAsync<List<Producto>>("api/v1.0/productos") ?? new List<Producto>();

        public async Task<Producto?> GetByIdAsync(int id) =>
            await _http.GetFromJsonAsync<Producto>($"api/v1.0/productos/{id}");

        public async Task<Producto?> CreateAsync(Producto p)
        {
            var response = await _http.PostAsJsonAsync("api/v1.0/productos", p);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<Producto>();
        }

        public async Task<bool> UpdateAsync(int id, Producto p)
        {
            var response = await _http.PutAsJsonAsync(($"api/v1.0/productos/{id}"), p);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync(($"api/v1.0/productos/{id}"));
            return response.IsSuccessStatusCode;
        }
    }
}