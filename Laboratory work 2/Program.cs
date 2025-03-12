using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_work_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SalesReport report = new SalesReport();

            report.AddSale(new SalesRealization(1, new Game("The Witcher 3: Wild Hunt", 2923.00, 10, Genre.Action)));
            report.AddSale(new SalesRealization(1, new Game("Red Dead Redemption II", 1690.00, 8, Genre.Adventure)));
            report.AddSale(new SalesRealization(2, new Game("The Elder Scrolls V: Skyrim", 1391.00, 5, Genre.RPG)));
            report.AddSale(new SalesRealization(2, new Game("Grand Theft Auto V", 1449.00, 14, Genre.Action)));
            report.AddSale(new SalesRealization(3, new Game("Tomb Raider", 1069.00, 16, Genre.Adventure)));
            report.AddSale(new SalesRealization(3, new Game("The Elder Scrolls V: Skyrim", 1391.00, 5, Genre.RPG)));

            int reportType;
            Console.WriteLine("Выберите вид отчёта (0 - весь, 1 - по дням, 2 - по жанрам): ");
            reportType = Convert.ToInt32(Console.ReadLine());
            if (reportType == 0)
            {
                report.PrintReportAll();
            }
            else if (reportType == 1)
            {
                report.PrintReportPerDay();
            }
            else if (reportType == 2)
            {
                report.PrintReportPerGenre();
            }
            else
            {
                Console.WriteLine("Недопустимое значение");
            }
        }
    }
}
