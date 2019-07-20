using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DomainServices.Services
{
   public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        Task<Customer> GetCustomerAsync(int id);
        void InsertCustomer(Customer Customer);
        Task<int> InsertCustomerAsync(Customer Customer);
        void AddCustomer(Customer Customer);
        void UpdateCustomer(Customer Customer);
        Task<int> UpdateCustomerAsync(Customer Customer);
        void DeleteCustomer(int id);
        Task<int> DeleteCustomerAsync(int id);
        void SaveChanges();
        bool CustomerExists(int id);
    }
}
