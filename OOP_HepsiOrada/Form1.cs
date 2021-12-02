using OOP_HepsiOrada.DAL;
using OOP_HepsiOrada.Entities;
using OOP_HepsiOrada.FakeDB;
using OOP_HepsiOrada.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_HepsiOrada
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductRepository productRepository;
        ShoppingChartRepository ShoppingChartRepository;
        ShoppingChart shoppingChart;
        private void Form1_Load(object sender, EventArgs e)
        {
            DummyData.Seed();
            productRepository = new ProductRepository();
            shoppingChart = new ShoppingChart();
            ShoppingChartRepository = new ShoppingChartRepository();
            FillForm();
            
        }
        public void FillForm()
        {
            cmbProducts.Items.Clear();
            cmbProducts.Items.Insert(0, "Seçiniz");
            List<Product> products = productRepository.Get();
            foreach (var product in products)
            {
                cmbProducts.Items.Add(product);
            }
            cmbProducts.SelectedIndex = 0;
        }

        int selectedproductId = 0;
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (cmbProducts.SelectedIndex<=0)
            {
                Utility.ShowErrorMessage("Lütfen seçim yapınız.");
                return;
            }
            var shoppingchart = new ShoppingChart();
            shoppingchart.Id = selectedproductId;
            shoppingchart.ShoppingChartName = cmbProducts.SelectedItem.ToString();
            shoppingchart.ShoppingChartPrice = (cmbProducts.SelectedItem as Product).ProductPrice;
            shoppingchart.ShoppingChartQuantity = Convert.ToInt32(nuQuantity.Value);
            shoppingchart.ShoppingChartValue =(grdShoppingChart.Rows.Count)+1;
            
            if (selectedproductId==0)
            {
                ShoppingChartRepository.Add(shoppingchart);
            }
            else
            {
                ShoppingChartRepository.Update(shoppingchart);
            }
            RefreshProducts();
            FormClear();
            ProductQuantityRefresh();
           
        }


        private void RefreshProducts()
        {
            grdShoppingChart.DataSource = null;
            grdShoppingChart.DataSource = ShoppingChartRepository.Get();
            GridProductVis();
        }
        private void GridProductVis()
        {
            grdShoppingChart.Columns["Id"].Visible = false;
            grdShoppingChart.Columns["ShoppingChartValue"].HeaderText = "Sıra No";
            grdShoppingChart.Columns["ShoppingChartName"].HeaderText = "Ürün Adı";
            grdShoppingChart.Columns["ShoppingChartQuantity"].HeaderText = "Adet";
            grdShoppingChart.Columns["ShoppingChartPrice"].HeaderText = "Fiyat";
        }

        private void FormClear()
        {
            cmbProducts.SelectedIndex = 0;
            nuQuantity.Value = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdShoppingChart.SelectedRows.Count>0)
            {
                var result = Utility.ShowDialogResultInformationMessage("Bu ürünü alışveriş sepetinizden çıkarmak istiyormusunuz?");
                if (result==DialogResult.OK)
                {
                    var items = grdShoppingChart.DataSource as List<ShoppingChart>;
                    var index = grdShoppingChart.SelectedRows[0].Index;
                    var item = items[index];
                    if (item!=null)
                    {
                        ShoppingChartRepository.Delete(item.Id);
                        Utility.ShowSuccessMessage("Seçmiş olduğunuz ürün alışveriş sepetinizden çıkarıldı.");
                    }
                    RefreshProducts();
                    ProductQuantityRefresh();
                    
                }
            }
        }
        private void ProductQuantityRefresh()
        {
            int totalQuantity = Convert.ToInt32(grdShoppingChart.Rows.Count);
            lblShoppingChart.Text = $"{totalQuantity} Adet";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Hesapla();
            Utility.ShowSuccessMessage( $" Sipariş Özetiniz: \n {lblPrice.Text} adet ürün \n Toplam Fiyat={lblPrice.Text} TL");
            EkranıTemizle();
        }
        private void Hesapla()
        {
            decimal totalPrice = 0;
            for (int i = 0; i < ShoppingChartRepository.Get().Count; i++)
            {
                totalPrice += ShoppingChartRepository.Get()[i].ShoppingChartPrice * ShoppingChartRepository.Get()[i].ShoppingChartQuantity;

            }
            lblPrice.Text = $"{totalPrice}";
        }
        private void EkranıTemizle()
        {
            cmbProducts.SelectedIndex = 0;
            nuQuantity.Value = 0;
            lblPrice.Text = " TL";
            lblShoppingChart.Text = " Adet";
            grdShoppingChart.DataSource = null;
        }

    }
}
