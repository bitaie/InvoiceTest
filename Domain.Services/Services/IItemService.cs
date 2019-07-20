using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DomainServices.Services
{
    public interface IItemService
    {
        IEnumerable<Item> GetItems();
        Item GetItem(int id);
        Task<Item> GetItemAsync(int id);
        void InsertItem(Item Item);
        Task<int> InsertItemAsync(Item Item);
        void AddItem(Item Item);
        void UpdateItem(Item Item);
        Task<int> UpdateItemAsync(Item Item);
        void DeleteItem(int id);
        Task<int> DeleteItemAsync(int id);
        void SaveChanges();
        bool ItemExists(int id);
    }
}
