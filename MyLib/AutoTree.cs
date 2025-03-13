using MyLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class AutoTree
    {
       private List<TreeNodeModel> treeData_ = new List<TreeNodeModel>();

        public AutoTree() 
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

        public List<TreeNodeModel> GetData()
        {
            return treeData_;
        }
    }
}
