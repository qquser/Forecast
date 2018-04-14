using Common.DTO;
using Management.Economics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var revenueList = new List<RevenueDTO>();
            revenueList.Add(new RevenueDTO { Month = 1, Revenue = 11602710.6694915 });
            revenueList.Add(new RevenueDTO { Month = 2, Revenue = 12044305.3898305 });
            revenueList.Add(new RevenueDTO { Month = 3, Revenue = 12273332.5847458 });

            var forecast = new Forecast(0.7, 0.15, 0.1, 1, revenueList);
            var gagr5 = forecast.Gagr5;
            var acc = forecast.Accuracy;

        }
    }
}
