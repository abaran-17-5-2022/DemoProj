using DemoProj.Shared.Models;

namespace DemoProj.Client.Services
{
    public interface IAddressService
    {
        Task<List<AddressDB>?> GetAddress();

        Task<List<AddressDB>?> GetAddressByName(string name);

        Task<AddressDB?> GetAddressById(int id);

        Task AddAddress(AddressDB address);

        Task DeleteAddress(int id);

        Task EditAddress(int id, AddressDB address);
    }
}
