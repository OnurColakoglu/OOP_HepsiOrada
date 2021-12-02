using OOP_HepsiOrada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HepsiOrada.FakeDB
{
    public class ProductsDataBase
    {
        public static int ProductTableId = 0;
        public static List<Product> products = new List<Product>();

        public static int ShoppinChartId = 0;
        public static List<ShoppingChart> ShoppingChart = new List<ShoppingChart>();
    }
}
