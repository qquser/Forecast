using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class RevenueResultDTO
    {
        public double Revenue { get; set; }

        public int Month { get; set; }

        public double CftK { get; set; }
        public double CftB { get; set; }
        public double CftQ { get; set; }

        public double ForecastForModelEvaluation { get; set; }
        public double ModelError { get; set; }
        public double ModelErrorDeviation { get; set; }
    }
}
