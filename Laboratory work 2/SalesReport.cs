using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_work_2
{
    public class SalesReport
    {
        private List<SalesRealization> salesRealizations;
        
        public SalesReport()
        {
            salesRealizations = new List<SalesRealization>();
        }

        public void AddSale(SalesRealization realization)
        {
            salesRealizations.Add(realization);
        }

        public void PrintReportAll()
        {
            double totalRevenue = 0;
            foreach (var realization in salesRealizations)
            {
                var game = realization.GetGame();

                Console.WriteLine($"День: {realization.GetDay()}, Название игры: {game.GetName()}, Жанр: {game.GetGenre()}, цена: {game.GetPrice()}, количество: {game.GetQuantity()}, выручка от игры: {game.GetPrice() * game.GetQuantity()}");
                totalRevenue += game.GetQuantity() * game.GetPrice();
            }
            Console.WriteLine($"Общая выручка: {totalRevenue}");
        }

        public void PrintReportPerDay()
        {
            int day;
            Console.WriteLine("Выберите день: ");
            day = Convert.ToInt32(Console.ReadLine());
            double totalRevenue = 0;
            foreach (var realization in salesRealizations)
            {
                var game = realization.GetGame();
                if (day == realization.GetDay())
                {
                    Console.WriteLine($"День: {realization.GetDay()}, Название игры: {game.GetName()}, Жанр: {game.GetGenre()}, цена: {game.GetPrice()}, количество: {game.GetQuantity()}, выручка от игры: {game.GetPrice() * game.GetQuantity()}");
                    totalRevenue += game.GetQuantity() * game.GetPrice();
                }
            }
            if (totalRevenue != 0)
            {
                Console.WriteLine($"Общая выручка: {totalRevenue}");
            }
            if (totalRevenue == 0)
            {
                Console.WriteLine("В данный день продаж не было.");
            }
        }

        public void PrintReportPerGenre()
        {
            string genre;
            Console.WriteLine("Введите жанр: ");
            genre = Console.ReadLine();
            double totalRevenue = 0;
            foreach (var realization in salesRealizations)
            {
                var game = realization.GetGame();
                if (genre == Convert.ToString(game.GetGenre()))
                {
                    Console.WriteLine($"День: {realization.GetDay()}, Название игры: {game.GetName()}, Жанр: {game.GetGenre()}, цена: {game.GetPrice()}, количество: {game.GetQuantity()}, выручка от игры: {game.GetPrice() * game.GetQuantity()}");
                    totalRevenue += game.GetQuantity() * game.GetPrice();
                }
            }
            if (totalRevenue != 0)
            {
                Console.WriteLine($"Общая выручка: {totalRevenue}");
            }
            if (totalRevenue == 0)
            {
                Console.WriteLine("Введённый жанр не найден.");
            }
        }
    }
}
