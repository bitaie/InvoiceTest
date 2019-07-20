using DomainServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DomainServices.Services
{
    public class ItemService : IItemService
    {
        private IRepository<Item> ItemRepository;


        public ItemService(IRepository<Item> ItemRepository)
        {
            this.ItemRepository = ItemRepository;

        }

        public IEnumerable<Item> GetItems()
        {
            return ItemRepository.GetAll();
        }

        public Item GetItem(int id)
        {
            return ItemRepository.Get(id);
        }
        public async Task<Item> GetItemAsync(int id)
        {
            return await ItemRepository.GetAsync(id);
        }

        public void InsertItem(Item Item)
        {
            ItemRepository.Insert(Item);
        }
        public void AddItem(Item Item)
        {
            ItemRepository.Add(Item);
        }
        public void UpdateItem(Item Item)
        {
            ItemRepository.Update(Item);
        }
        public async Task<int> UpdateItemAsync(Item Item)
        {
            return await ItemRepository.UpdateAsync(Item);
        }

        public void DeleteItem(int id)
        {

            Item Item = GetItem(id);
            ItemRepository.Remove(Item);
            ItemRepository.SaveChanges();
        }
        public async Task<int> DeleteItemAsync(int id)
        {
            Item Item = GetItem(id);
            return await ItemRepository.DeleteAsync(Item);
        }
        public void SaveChanges()
        {


            ItemRepository.SaveChanges();

        }
        public bool ItemExists(int id)
        {
            return ItemRepository.Exists(id);
        }



        public async Task<int> InsertItemAsync(Item Item)
        {
            return await ItemRepository.InsertAsync(Item);
        }
    }
}