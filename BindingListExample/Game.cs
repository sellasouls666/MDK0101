using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingListExample
{
    public class Game
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public DateTime Release { get; set; }


        public string GetName()
        {
            return Name;
        }

        public string GetGenre()
        {
            return Genre;
        }

        public double GetPrice()
        {
            return Price;
        }

        public DateTime GetRelease()
        {
            return Release;
        }
    }
}
