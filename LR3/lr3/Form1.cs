using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace lr3
{
    public partial class Form1 : Form
    {
        public string result1;
        public Form1()
        {
            InitializeComponent();
            generateProductList();
            string result = "Ваш список заказов: \r\n";
            textBox1.Text = result;
        }

        private Dictionary<string, string[]> products = new Dictionary<string, string[]>()
        {
            {"Хлебобулочные", new string[] {"Хлеб", "Батон", "Сушки"}},
            {"Фрукты", new string[] {"Яблоки", "Груши", "Бананы"}},
            {"Овощи", new string[] {"Огурцы", "Помидоры", "Баклажаны"}}
        };

        private void productList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productList.SelectedItem != null)
            {
                string selectedItem = productList.SelectedItem.ToString();

                    product1.Text = products[selectedItem][0];
                    product2.Text = products[selectedItem][1];
                    product3.Text = products[selectedItem][2];
            }
        }

        private void generateProductList()
        {

            foreach (string key in products.Keys)
            {
                productList.Items.Add(key);
            }
        }

        private void createOrder_Click(object sender, EventArgs e)
        {
            if (product1.Checked)
            {
                result1 += $"{product1.Text}: {productQuantity1.Value}\r\n";
            }
            if (product2.Checked)
            {
                result1 += $"{product2.Text} :  {productQuantity2.Value}\r\n";
            }
            if (product3.Checked)
            {
                result1 += $"{product3.Text} :  {productQuantity3.Value}\r\n";
            }

            textBox1.Text += result1;
            result1 = " ";

        }
    }
}
