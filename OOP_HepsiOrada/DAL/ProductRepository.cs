using OOP_HepsiOrada.Entities;
using OOP_HepsiOrada.FakeDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HepsiOrada.DAL
{
    public class ProductRepository
    {
        public void Add(Product product)
        {
            product.Id = (++ProductsDataBase.ProductTableId);
            ProductsDataBase.products.Add(product);
        }
        public Product FindById(int id)
        {
            Product product = ProductsDataBase.products.FirstOrDefault(t0 => t0.Id == id);
            return product;
        }
        public List<Product> Get()
        {
            return ProductsDataBase.products;
        }

        public void Update(Product product)
        {
            var dbItem = FindById(product.Id);
            if (dbItem != null)
            {
                dbItem.ProductCode = product.ProductCode;
                dbItem.ProductName = product.ProductName;
                dbItem.ProductPrice = product.ProductPrice;
                dbItem.ProductQuantity = product.ProductQuantity;
            }
        }
        public void Delete(int id)
        {
            var dbItem = FindById(id);
            if (dbItem != null)
            {
                ProductsDataBase.products.Remove(dbItem);
            }
        }
    }
}
