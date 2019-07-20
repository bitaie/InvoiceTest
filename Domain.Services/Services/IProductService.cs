using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;


namespace DomainServices.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        Task<Product> GetProductAsync(int id);
        List<string> GetAllProductList();
        void InsertProduct(Product Product);
        Task<int> InsertProductAsync(Product Product);
        void AddProduct(Product Product);
        void UpdateProduct(Product Product);
        Task<int> UpdateProductAsync(Product Product);
        void DeleteProduct(int id);
        Task<int> DeleteProductAsync(int id);
        void SaveChanges();
        bool ProductExists(int id);
    }
}
