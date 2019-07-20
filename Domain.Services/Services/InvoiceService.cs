using DomainServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DomainServices.Services
{
    public class InvoiceService : IInvoiceService
    {
        private IRepository<Invoice> InvoiceRepository;
        private IRepository<Item> ItemRepository;


        public InvoiceService(IRepository<Invoice> InvoiceRepository, IRepository<Item> ItemRepository)
        {
            this.InvoiceRepository = InvoiceRepository;
            this.ItemRepository = ItemRepository;
            

        }

        public IEnumerable<Invoice> GetInvoices()
        {
            return InvoiceRepository.GetAll();
        }

        public Invoice GetInvoice(int id)
        {
            return InvoiceRepository.Get(id);
        }
        public async Task<Invoice> GetInvoiceAsync(int id)
        {
            return await InvoiceRepository.GetAsync(id);
        }

        public void InsertInvoice(Invoice Invoice,IEnumerable<Item> Items)
        {
            
            InvoiceRepository.Insert(Invoice);
            ItemRepository.SaveChanges();

        }
        public void AddInvoice(Invoice Invoice)
        {
            InvoiceRepository.Add(Invoice);
        }
        public void UpdateInvoice(Invoice Invoice)
        {
            InvoiceRepository.Update(Invoice);
        }
        public async Task<int> UpdateInvoiceAsync(Invoice Invoice)
        {
            return await InvoiceRepository.UpdateAsync(Invoice);
        }

        public void DeleteInvoice(int id)
        {

            Invoice Invoice = GetInvoice(id);
            InvoiceRepository.Remove(Invoice);
            InvoiceRepository.SaveChanges();
        }
        public async Task<int> DeleteInvoiceAsync(int id)
        {
            Invoice Invoice = GetInvoice(id);
            return await InvoiceRepository.DeleteAsync(Invoice);
        }
        public void SaveChanges()
        {


            InvoiceRepository.SaveChanges();

        }
        public bool InvoiceExists(int id)
        {
            return InvoiceRepository.Exists(id);
        }



        public async Task<int> InsertInvoiceAsync(Invoice Invoice)
        {
            return await InvoiceRepository.InsertAsync(Invoice);
        }
    }
}