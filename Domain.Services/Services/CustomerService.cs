using DomainServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DomainServices.Services
{
    public class CustomerService : ICustomerService
    {
        private IRepository<Customer> CustomerRepository;


        public CustomerService(IRepository<Customer> CustomerRepository)
        {
            this.CustomerRepository = CustomerRepository;

        }

        public IEnumerable<Customer> GetCustomers()
        {
            return CustomerRepository.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            return CustomerRepository.Get(id);
        }
        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await CustomerRepository.GetAsync(id);
        }

        public void InsertCustomer(Customer Customer)
        {
            CustomerRepository.Insert(Customer);
        } public void AddCustomer(Customer Customer)
        {
            CustomerRepository.Add(Customer);
        }
        public void UpdateCustomer(Customer Customer)
        {

            CustomerRepository.Update(Customer);
        }
        public async Task<int> UpdateCustomerAsync(Customer Customer)
        {
           return await CustomerRepository.UpdateAsync(Customer);
        }

        public void DeleteCustomer(int id)
        {

            Customer Customer = GetCustomer(id);
            CustomerRepository.Remove(Customer);
            CustomerRepository.SaveChanges();
        }
        public async Task<int> DeleteCustomerAsync(int id)
        {
            Customer Customer = GetCustomer(id);
            return await CustomerRepository.DeleteAsync(Customer);
        }
            public void SaveChanges()
        {

            
            CustomerRepository.SaveChanges();
           
        }
        public bool CustomerExists(int id)
        {
            return CustomerRepository.Exists(id);
        }

       

        public async Task<int> InsertCustomerAsync(Customer Customer)
        {
           return await CustomerRepository.InsertAsync(Customer);
        }
    }
}