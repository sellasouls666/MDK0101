using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_work_2
{
    public class SalesRealization
    {
        private int day_;
        private Game game_;

        public SalesRealization(int day, Game game)
        {
            day_ = day;
            game_ = game;
        }

        public int GetDay()
        {
            return day_;
        }

        public Game GetGame()
        {
            return game_;
        }
    }
}
