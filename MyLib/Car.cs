using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Car
    {
        public string Name { get; set; }
        public string Engine { get; set; }
        public string Power { get; set; }
        public string Transmissionbox { get; set; }
        public string Drive { get; set; }
        public string Color { get; set; }
        public string Mileage { get; set; }


       /* public static Dictionary<string, string> Aliases = new Dictionary<string, string>()
        {
            { nameof(Name), "Наименование"},
            { nameof(Engine), "Двигатель"},
            { nameof(Power), "Мощность"},
            { nameof(Transmissionbox), "Коробка передач"},
            { nameof(Drive), "Привод"},
            { nameof(Color), "Цвет"},
            { nameof(Mileage), "Пробег"}
          


        }; */
    }
}
