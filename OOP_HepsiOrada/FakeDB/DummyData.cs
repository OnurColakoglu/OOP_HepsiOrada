
using OOP_HepsiOrada.DAL;
using OOP_HepsiOrada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HepsiOrada.FakeDB
{
    public class DummyData
    {
        
        public static void Seed()
        {       
            ProductRepository productRepository = new ProductRepository();
            Product product1 = new Product() { ProductCode = "P01", ProductName = "Ekran", ProductPrice = 1500m };
            Product product2 = new Product() { ProductCode = "P02", ProductName = "Klavye", ProductPrice = 500m };
            Product product3 = new Product() { ProductCode = "P03", ProductName = "Mouse", ProductPrice = 200m };
            Product product4 = new Product() { ProductCode = "P04", ProductName = "Grafik Kartı", ProductPrice = 11500m };
            Product product5 = new Product() { ProductCode = "P05", ProductName = "Dahili Bellek", ProductPrice = 400m };
            Product product6 = new Product() { ProductCode = "P05", ProductName = "Ram", ProductPrice = 800m };
            Product product7 = new Product() { ProductCode = "P07", ProductName = "İşlemci", ProductPrice = 3500m };
            Product product8 = new Product() { ProductCode = "P08", ProductName = "Güç Kaynağı", ProductPrice = 850m };
            Product product9 = new Product() { ProductCode = "P09", ProductName = "İşletim Sistemi", ProductPrice = 2000m };
            Product product10 = new Product() { ProductCode = "P10", ProductName = "Anakart", ProductPrice = 1500m };
            productRepository.Add(product1);
            productRepository.Add(product2);
            productRepository.Add(product3);
            productRepository.Add(product4);
            productRepository.Add(product5);
            productRepository.Add(product7);
            productRepository.Add(product8);
            productRepository.Add(product9);
            productRepository.Add(product10);
        }
    }
}
