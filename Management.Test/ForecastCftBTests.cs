using Common.DTO;
using Management.Economics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Test
{
    [TestClass]
    public class ForecastCftBTests
    {
        [TestMethod]
        public void FirstTestMethodForCftB()
        {
            var revenueList = new List<RevenueDTO>();
            revenueList.Add(new RevenueDTO { Month = 1, Revenue = 11602710.6694915 });

            var forecast = new Forecast(0.7, 0.15, 0.1, 1, revenueList);
            var list = forecast.RevenueLinkedList.ToList();
            var b = list[0].CftB;
            Assert.AreEqual(b, 0);
        }

        [TestMethod]
        public void SecondTestMethodForCftB()
        {
            var revenueList = new List<RevenueDTO>();
            revenueList.Add(new RevenueDTO { Month = 1, Revenue = 11602710.6694915 });
            revenueList.Add(new RevenueDTO { Month = 2, Revenue = 12044305.3898305 });

            var forecast = new Forecast(0.7, 0.15, 0.1, 1, revenueList);
            var list = forecast.RevenueLinkedList.ToList();
            var b = Math.Round(list[1].CftB, 5);
            Assert.AreEqual(b, 46367.44564);
        }

        [TestMethod]
        public void TestMethod3ForCftB()
        {
            var revenueList = new List<RevenueDTO>();
            revenueList.Add(new RevenueDTO { Month = 1, Revenue = 11602710.6694915 });
            revenueList.Add(new RevenueDTO { Month = 2, Revenue = 12044305.3898305 });
            revenueList.Add(new RevenueDTO { Month = 3, Revenue = 12273332.5847458 });

            var forecast = new Forecast(0.7, 0.15, 0.1, 1, revenueList);
            var list = forecast.RevenueLinkedList.ToList();
            var b = Math.Round(list[2].CftB,7 );
            Assert.AreEqual(b, 79456.9530006);
        }
    }
}
