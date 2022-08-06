using DemoProj.Shared.Models;
using System.Net.Http.Json;

namespace DemoProj.Client.Services
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddAddress(AddressDB address)
        {
            if (address.street != "" && address.state != "" && address.country != "")
            await _httpClient.PutAsJsonAsync<AddressDB>("address", address);
        }

        public async Task DeleteAddress(int id)
        {
            await _httpClient.DeleteAsync($"address/{id}");
        }

        public async Task EditAddress(int id, AddressDB address)
        {
            if (address.street != "" && address.state != "" && address.country != "")
            await _httpClient.PutAsJsonAsync<AddressDB>($"address/{id}", address);
        }

        public async Task<List<AddressDB>?> GetAddress()
        {
            return await _httpClient.GetFromJsonAsync<List<AddressDB>>("address");
        }

        public async Task<AddressDB?> GetAddressById(int id)
        {
            return await _httpClient.GetFromJsonAsync<AddressDB>($"address/{id}");
        }

        public async Task<List<AddressDB>?> GetAddressByName(string name)
        {
            return await _httpClient.GetFromJsonAsync<List<AddressDB>>($"address/search/{name}");
        }
    }
}
