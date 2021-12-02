using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HepsiOrada.Entities
{
    public class ShoppingChart
    {
        public int Id { get; set; }
        public string ShoppingChartName { get; set; }
        public decimal ShoppingChartPrice { get; set; }
        public int ShoppingChartQuantity { get; set; }
        public int ShoppingChartValue { get; set; }

    }
}
