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
        private List<TreeNodeModel> treeData_;
        private CarModel carsModel_;
        public MainForm()
        {
            InitializeComponent();

            treeData_ = new List<TreeNodeModel>();
            carsModel_ = new CarModel();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            {
                treeData_.Add(new TreeNodeModel("Машины"));
                var carNode = treeData_[0];
                var easierCar = carNode.AddChildNode("Легковые");
                var sedanCar = easierCar.AddChildNode("Седаны");
                sedanCar.AddChildNode("Lexus GS350");
                sedanCar.AddChildNode("Audi A7");
                sedanCar.AddChildNode("Infiniti G25");
                var cupeCar = easierCar.AddChildNode("Купе");
                cupeCar.AddChildNode("BMW 6-series");
                cupeCar.AddChildNode("Kia K3");
                cupeCar.AddChildNode("Audi A5");
                var hatchbackCar = easierCar.AddChildNode("Хэтчбеки");
                hatchbackCar.AddChildNode("Lexus CT200h");
                hatchbackCar.AddChildNode("Audi A1");
                hatchbackCar.AddChildNode("Toyota Spade");

                var harderCar = carNode.AddChildNode("Грузовые");
              
                var scepkiHarderCar = harderCar.AddChildNode("Бортовые");
                scepkiHarderCar.AddChildNode("Sollers Argo");
                scepkiHarderCar.AddChildNode("Dongfeng Captain-T");
                scepkiHarderCar.AddChildNode("JAC: N-35/25");

                var solosHarderCar = harderCar.AddChildNode("Самосвалы");
                solosHarderCar.AddChildNode("MAN TGS 6×4");
                solosHarderCar.AddChildNode("MAN TGM III 4×4");
                solosHarderCar.AddChildNode("ISUZU GIGA 6х4 Euro-5");
            }

            FillTreeNodeCollection(treeData_, MyTreeView.Nodes);


            MyTreeView.ExpandAll();

           //FillTableAliases();
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

        }

        private void LoadCar_Click(object sender, EventArgs e)
        {

        }
    }
}
