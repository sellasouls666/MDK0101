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
        private BindingList<Car> Cars = new BindingList<Car>();
        public MainForm()
        {
            InitializeComponent();
            treeData_ = new AutoTree();
            carsModel_ = new CarModel();
            Table.DataSource = Cars;
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
                    Cars.Add(selectedCar);
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
            AutoTree loadedTree = SaveAndLoadCsv.LoadTreeFromCsv(); // Загружаем дерево

            if (loadedTree != null)
            {
                // Очищаем TreeView
                MyTreeView.Nodes.Clear(); // treeView1 - ваш TreeView на форме

                // Получаем список корневых узлов из загруженного дерева
                List<TreeNodeModel> rootNodes = loadedTree.GetData();

                // Заполняем TreeView новыми узлами
                foreach (TreeNodeModel rootNode in rootNodes)
                {
                    PopulateTreeView(MyTreeView, rootNode); // Заполняем дерево новыми данными
                }

            }
            else
            {
                MessageBox.Show("Загрузка дерева из CSV отменена или произошла ошибка."); // Сообщаем об ошибке
            }
            MyTreeView.ExpandAll();
        }
        private void PopulateTreeView(System.Windows.Forms.TreeView treeView, TreeNodeModel treeNodeModel, TreeNode parentNode = null)
        {
            TreeNode node = new TreeNode(treeNodeModel.Name);

            if (parentNode == null)
            {
                // Если нет родительского узла, добавляем в корневые узлы TreeView
                treeView.Nodes.Add(node);
            }
            else
            {
                // Иначе добавляем как дочерний узел к родительскому узлу
                parentNode.Nodes.Add(node);
            }

            // Рекурсивно вызываем для дочерних узлов
            foreach (TreeNodeModel childNodeModel in treeNodeModel.Children)
            {
                PopulateTreeView(treeView, childNodeModel, node);
            }
        }
    }
}
