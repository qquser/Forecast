using System;
using System.Collections.Generic;
using System.Linq;
using Common.DTO;
using Management.Economics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Management.Test
{
    [TestClass]
    public class ForecastCftKTests
    {
        [TestMethod]
        public void FirstTestMethodForCftK()
        {
            var revenueList = new List<RevenueDTO>();
            revenueList.Add(new RevenueDTO { Month = 1, Revenue = 11602710.6694915 });

            var forecast = new Forecast(0.7, 0.15, 0.1, 1, revenueList);
            var list = forecast.RevenueLinkedList.ToList();
            var k = list[0].CftK;
            Assert.AreEqual(k, 11602710.6694915);
        }

        [TestMethod]
        public void SecondTestMethodForCftK()
        {
            var revenueList = new List<RevenueDTO>();
            revenueList.Add(new RevenueDTO { Month = 1, Revenue = 11602710.6694915 });
            revenueList.Add(new RevenueDTO { Month = 2, Revenue = 12044305.3898305 });

            var forecast = new Forecast(0.7, 0.15, 0.1, 1, revenueList);
            var list = forecast.RevenueLinkedList.ToList();
            var k = list[1].CftK;
            Assert.AreEqual(k, 11911826.9737288);
        }

        [TestMethod]
        public void TestMethod3ForCftK()
        {
            var revenueList = new List<RevenueDTO>();
            revenueList.Add(new RevenueDTO { Month = 1, Revenue = 11602710.6694915 });
            revenueList.Add(new RevenueDTO { Month = 2, Revenue = 12044305.3898305 });
            revenueList.Add(new RevenueDTO { Month = 3, Revenue = 12273332.5847458 });

            var forecast = new Forecast(0.7, 0.15, 0.1, 1, revenueList);
            var list = forecast.RevenueLinkedList.ToList();
            var k = Math.Round(list[2].CftK, 7);
            Assert.AreEqual(k, 12178791.1351314);
        }
    }
}
