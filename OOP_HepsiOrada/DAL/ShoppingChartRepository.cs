using OOP_HepsiOrada.Entities;
using OOP_HepsiOrada.FakeDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HepsiOrada.DAL
{
    public class ShoppingChartRepository
    {
        public void Add (ShoppingChart item)
        {
            item.Id = (++ProductsDataBase.ProductTableId);
            ProductsDataBase.ShoppingChart.Add(item);
        }
        public ShoppingChart FindById(int id)
        {
            ShoppingChart shopping = ProductsDataBase.ShoppingChart.FirstOrDefault(t0 => t0.Id == id);
            return shopping;
        }
        public List<ShoppingChart> Get()
        {
            return ProductsDataBase.ShoppingChart;
        }
        public void Update(ShoppingChart item)
        {
            var dbItem = FindById(item.Id);
            if (dbItem!=null)
            {
                dbItem.Id = item.Id;
                dbItem.ShoppingChartQuantity = item.ShoppingChartQuantity;
                dbItem.ShoppingChartName = item.ShoppingChartName;
                dbItem.ShoppingChartPrice = item.ShoppingChartPrice;
                
                
            }

        }
        public void Delete(int id)
        {
            var dBItem = FindById(id);
            if (dBItem!=null)
            {
                ProductsDataBase.ShoppingChart.Remove(dBItem);
            }
            {

            }
        }
    }
}
