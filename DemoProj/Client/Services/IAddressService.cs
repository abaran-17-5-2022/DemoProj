using DemoProj.Shared.Models;

namespace DemoProj.Client.Services
{
    public interface IAddressService
    {
        Task<List<Address>?> GetAddresses();

        Task<List<Address>?> GetAddressesByName(string name);

        Task<Address?> GetAddressesById(int id);

        Task AddAddress(Address address);

        Task DeleteAddress(int id);

        Task EditAddress(int id, Address address);
    }
}
