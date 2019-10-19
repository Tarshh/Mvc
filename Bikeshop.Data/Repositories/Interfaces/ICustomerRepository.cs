using Domain;
using Microsoft.AspNetCore.Identity;

namespace Bikeshop.Models.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        Customer GetCustomer(string customerId);
    }
}
