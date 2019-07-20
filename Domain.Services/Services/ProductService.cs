using DomainServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DomainServices.Services
{
    public class ProductService : IProductService
    {
        private IRepository<Product> ProductRepository;


        public ProductService(IRepository<Product> ProductRepository)
        {
            this.ProductRepository = ProductRepository;

        }

        public IEnumerable<Product> GetProducts()
        {
            return ProductRepository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return ProductRepository.Get(id);
        }
        public async Task<Product> GetProductAsync(int id)
        {
            return await ProductRepository.GetAsync(id);
        }

        public void InsertProduct(Product Product)
        {
            ProductRepository.Insert(Product);
        }
        public void AddProduct(Product Product)
        {
            ProductRepository.Add(Product);
        }
        public void UpdateProduct(Product Product)
        {
            ProductRepository.Update(Product);
        }
        public async Task<int> UpdateProductAsync(Product Product)
        {
            return await ProductRepository.UpdateAsync(Product);
        }

        public void DeleteProduct(int id)
        {

            Product Product = GetProduct(id);
            ProductRepository.Remove(Product);
            ProductRepository.SaveChanges();
        }
        public async Task<int> DeleteProductAsync(int id)
        {
            Product Product = GetProduct(id);
            return await ProductRepository.DeleteAsync(Product);
        }
        public void SaveChanges()
        {


            ProductRepository.SaveChanges();

        }
        public bool ProductExists(int id)
        {
            return ProductRepository.Exists(id);
        }



        public async Task<int> InsertProductAsync(Product Product)
        {
            return await ProductRepository.InsertAsync(Product);
        }

        public List<string> GetAllProductList()
        {
            var products = ProductRepository.GetAll();
            var productsList = new List<string>();
            foreach(var product in products)
            {
                productsList.Add(product.Brand +" "+ product.Name);
            }
            return productsList;

        }
    }
}