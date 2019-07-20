using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DomainServices.Services
{
    public interface IInvoiceService
    {
        IEnumerable<Invoice> GetInvoices();
        Invoice GetInvoice(int id);
        Task<Invoice> GetInvoiceAsync(int id);
        void InsertInvoice(Invoice Invoice, IEnumerable<Item> Items);
        Task<int> InsertInvoiceAsync(Invoice Invoice);
        void AddInvoice(Invoice Invoice);
        void UpdateInvoice(Invoice Invoice);
        Task<int> UpdateInvoiceAsync(Invoice Invoice);
        void DeleteInvoice(int id);
        Task<int> DeleteInvoiceAsync(int id);
        void SaveChanges();
        bool InvoiceExists(int id);
    }
}
