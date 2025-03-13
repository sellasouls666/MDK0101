using MyLib;
using MyLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyTreeView
{
    public partial class MainForm: Form
    {
        public AutoTree treeData_;
        private CarModel carsModel_;
        public MainForm()
        {
            InitializeComponent();
            treeData_ = new AutoTree();
            carsModel_ = new CarModel();
        }

        private void MainForm_Load(object sender, EventArgs e)
        { 
            FillTreeNodeCollection(treeData_.GetData(), MyTreeView.Nodes);
            MyTreeView.ExpandAll();
        }
        static private void FillTreeNodeCollection(List<TreeNodeModel> sourceData, 
                                                  TreeNodeCollection targetData) 
        {
            foreach (var node in sourceData)
            {
                var treeNode = new TreeNode(node.Name); 
                targetData.Add(treeNode);

                if (node.Children != null && node.Children.Count > 0)
                {
                    FillTreeNodeCollection(node.Children, treeNode.Nodes);
                }
            }
        }



        private void PopulateDataGridView(Car car)
        {
            DataGridViewRow row = new DataGridViewRow();

            row.Cells.Add(new DataGridViewTextBoxCell { Value = car.Name });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = car.Engine });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = car.Power });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = car.Transmissionbox });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = car.Drive });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = car.Color });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = car.Mileage });

            Table.Rows.Add(row);
        }

        private void MyTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = MyTreeView.SelectedNode;

            string Name = selectedNode.Text;

            if (Name != null)
            {
                Car selectedCar = carsModel_.FindCarByName(Name);

                if (selectedCar != null)
                {
                    PopulateDataGridView(selectedCar);
                }
                else
                {
                    MessageBox.Show("Автомобиль не найден.");
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {

            SaveAndLoadCsv.SaveTreeToCsv(treeData_);

        }

        private void LoadCar_Click(object sender, EventArgs e)
        {

        }
    }
}
