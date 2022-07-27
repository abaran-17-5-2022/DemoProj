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
        public async Task AddAddress(Address address)
        {
            if (address.address != "")
            await _httpClient.PutAsJsonAsync<Address>("address", address);
        }

        public async Task DeleteAddress(int id)
        {
            await _httpClient.DeleteAsync($"address/{id}");
        }

        public async Task EditAddress(int id, Address address)
        {
            if (address.address != "")
            await _httpClient.PutAsJsonAsync<Address>($"address/{id}", address);
        }

        public async Task<List<Address>?> GetAddresses()
        {
            return await _httpClient.GetFromJsonAsync<List<Address>>("address");
        }

        public async Task<Address?> GetAddressesById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Address>($"address/{id}");
        }

        public async Task<List<Address>?> GetAddressesByName(string name)
        {
            return await _httpClient.GetFromJsonAsync<List<Address>>($"address/search/{name}");
        }
    }
}
