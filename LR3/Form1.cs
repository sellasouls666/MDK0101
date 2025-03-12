using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LR3
{
    public partial class Form1 : Form
    {
        private Dictionary<string, List<string>> productGroups = new Dictionary<string, List<string>>()
        {
            { "Мясо и птица", new List<string>() { "Говядина", "Курица", "Свинина" } },
            { "Овощи", new List<string>() { "Помидоры", "Огурцы", "Морковь" } },
            { "Напитки", new List<string>() { "Вода", "Чай", "Сок" } }
        };

        private Dictionary<string, int> orderDetails = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
            LoadProductGroups();
        }

        private void LoadProductGroups()
        {
            groupListBox.Items.AddRange(productGroups.Keys.ToArray());
        }

        private void groupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemsPanel.Controls.Clear();
            orderDetails.Clear();
            if (groupListBox.SelectedItem != null)
            {
                string selectedGroup = groupListBox.SelectedItem.ToString();
                List<string> products = productGroups[selectedGroup];

                int top = 10;
                foreach (string product in products)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Text = product;
                    checkBox.Location = new System.Drawing.Point(10, top);
                    checkBox.AutoSize = true;
                    checkBox.Tag = product;
                    checkBox.CheckedChanged += CheckBox_CheckedChanged;

                    NumericUpDown numericUpDown = new NumericUpDown();
                    numericUpDown.Location = new System.Drawing.Point(checkBox.Right + 10, top - 3);
                    numericUpDown.Width = 50;
                    numericUpDown.Minimum = 0;
                    numericUpDown.Maximum = 100;
                    numericUpDown.Tag = product;
                    numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
                    numericUpDown.Enabled = false;

                    itemsPanel.Controls.Add(checkBox);
                    itemsPanel.Controls.Add(numericUpDown);

                    top += 30;
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string product = (string)checkBox.Tag;

            NumericUpDown numericUpDown = null;
            foreach (Control control in itemsPanel.Controls)
            {
                if (control is NumericUpDown && (string)control.Tag == product)
                {
                    numericUpDown = (NumericUpDown)control;
                    break;
                }
            }

            if (checkBox.Checked)
            {
                numericUpDown.Enabled = true;
                numericUpDown.Value = 1;
                orderDetails[product] = 1;
            }
            else
            {
                numericUpDown.Enabled = false;
                numericUpDown.Value = 0;
                orderDetails.Remove(product);
            }
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            string product = (string)numericUpDown.Tag;

            int quantity = (int)numericUpDown.Value;

            if (quantity > 0)
            {
                orderDetails[product] = quantity;
            }
            else
            {
                orderDetails.Remove(product);
            }
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            resultTextBox.Clear();
            resultTextBox.AppendText("Заказ:\r\n");

            foreach (var group in productGroups)
            {
                string groupName = group.Key;
                bool groupOrdered = false;

                resultTextBox.AppendText($"- {groupName}:\r\n");
                foreach (string product in group.Value)
                {
                    if (orderDetails.ContainsKey(product))
                    {
                        resultTextBox.AppendText($"  - {product}: {orderDetails[product]}\r\n");
                        groupOrdered = true;
                    }
                }

                if (!groupOrdered)
                {
                    resultTextBox.AppendText("  (Ничего не заказано)\r\n");
                }
            }
        }
    }
}
