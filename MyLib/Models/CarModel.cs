using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Models
{
    public class CarModel
    {
        public List<Car> Cars { get; }

        public CarModel()
        {
            Cars = new List<Car>();

            Cars.Add(new Car
            {
                Name = "Lexus GS350",
                Engine = "бензин, 3.5 л",
                Power = "317 л.с.",
                Transmissionbox = "АКПП",
                Drive = "4WD",
                Color = "серый",
                Mileage = "259 000 км"
            });

            Cars.Add(new Car
            {
                Name = "Audi A7",
                Engine = "бензин, 3.0 л",
                Power = "300 л.с.",
                Transmissionbox = "робот",
                Drive = "4WD",
                Color = "серый",
                Mileage = "204 172 км"
            });

            Cars.Add(new Car
            {
                Name = "Infiniti G25",
                Engine = "бензин, 2.5 л",
                Power = "222 л.с.",
                Transmissionbox = "АКПП",
                Drive = "задний",
                Color = "синий",
                Mileage = "255 000 км"
            });

            Cars.Add(new Car
            {
                Name = "BMW 6-series",
                Engine = "бензин, 4.8 л",
                Power = "367 л.с",
                Transmissionbox = "АКПП",
                Drive = "задний",
                Color = "черный",
                Mileage = "237 897 км"
            });

            Cars.Add(new Car
            {
                Name = "Kia K3",
                Engine = "бензин, 1.6 л",
                Power = "204 л.с.",
                Transmissionbox = "робот",
                Drive = "передний",
                Color = "синий",
                Mileage = "82 000 км"
            });
            Cars.Add(new Car
            {
                Name = "Audi A5",
                Engine = "бензин, 2.0 л",
                Power = "204 л.с.",
                Transmissionbox = "робот",
                Drive = "передний",
                Color = "зеленый",
                Mileage = "30 км"
            });
            Cars.Add(new Car
            {
                Name = "Lexus CT200h",
                Engine = "бензин, 1.8 л",
                Power = "99 л.с.",
                Transmissionbox = "вариатор",
                Drive = "передний",
                Color = "синий",
                Mileage = "125 000 км"
            });
            Cars.Add(new Car
            {
                Name = "Audi A1",
                Engine = "бензин, 1.4 л",
                Power = "122 л.с",
                Transmissionbox = "робот",
                Drive = "передний",
                Color = "белый",
                Mileage = "224 000 км"
            });
            Cars.Add(new Car
            {
                Name = "Toyota Spade",
                Engine = "бензин, 1.5 л",
                Power = "109 л.с",
                Transmissionbox = "вариатор",
                Drive = "передний",
                Color = "бордовый",
                Mileage = "148 000 км"
            });
            Cars.Add(new Car
            {
                Name = "Sollers Argo",
                Engine = "дизель, 2 л",
                Power = "130 л.с.",
                Transmissionbox = "механика",
                Drive = "задний",
                Color = "белый",
                Mileage = "новый"
            });
            Cars.Add(new Car
            {
                Name = "Dongfeng Captain-T",
                Engine = "дизель, 2.2 л",
                Power = "128",
                Transmissionbox = "механика",
                Drive = "задний",
                Color = "розовый",
                Mileage = "новый"
            });
            Cars.Add(new Car
            {
                Name = "JAC: N-35/25",
                Engine = "дизель, 2 л",
                Power = "129 л.с",
                Transmissionbox = "механика",
                Drive = "передний",
                Color = "синий",
                Mileage = "50 000 км"
            });
            Cars.Add(new Car
            {
                Name = "MAN TGS 6×4",
                Engine = "дизель, 10 л",
                Power = "440 л.с.",
                Transmissionbox = "механика",
                Drive = "полный",
                Color = "фиолетовый",
                Mileage = "1 086 804 км"
            });
            Cars.Add(new Car
            {
                Name = "MAN TGM III 4×4",
                Engine = "дизель, 6.9 л",
                Power = "320 л.с",
                Transmissionbox = "механика",
                Drive = "полный",
                Color = "белый",
                Mileage = "новый"
            });
            Cars.Add(new Car
            {
                Name = "ISUZU GIGA 6х4 Euro-5",
                Engine = "дизель, 15.7 л",
                Power = "400 л.с.",
                Transmissionbox = "МКПП",
                Drive = "задний",
                Color = "черный",
                Mileage = "20 000 км"
            });

        }

        public Car FindCarByName(string Name)
        {
            return Cars.FirstOrDefault(car => car.Name == Name);
        }
    }
}
