using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Economics
{
    public class Forecast : IForecast
    {
        private int _accuracy;
        public int Accuracy => _accuracy;

        private int _gagr5;
        public int Gagr5 => _gagr5;

        private LinkedList<RevenueResultDTO> _revenueLinkedList;
        public LinkedList<RevenueResultDTO> RevenueLinkedList => _revenueLinkedList;

        private double _k;
        private double _b;
        private double _q;
        private double _commonQ;

        public Forecast(double k, double b, double q, double commonQ, List<RevenueDTO> revenueList)
        {
            _revenueLinkedList = new LinkedList<RevenueResultDTO>();

            _k = k;
            _b = b;
            _q = q;
            _commonQ = commonQ;

            BuildList(revenueList);   
        }

        private void BuildList(List<RevenueDTO> revenueList)
        {      
            foreach (var item in revenueList.OrderBy(x=>x.Month))
            {
                RevenueResultDTO newItem = new RevenueResultDTO
                {
                    Revenue = item.Revenue,
                    Month  = item.Month,
                };
                _revenueLinkedList.AddLast(newItem);
            }

            CalculateLinkedList();
        }

        private void CalculateLinkedList()
        {
            LinkedListNode<RevenueResultDTO> current = _revenueLinkedList.First;
            while (current != null)
            {
                current.Value.CftK = GetK(current);
                current.Value.CftB = GetB(current);
                current.Value.CftQ = GetQ(current);
                current.Value.ForecastForModelEvaluation = GetForecastForModelEvaluation(current);
                current.Value.ModelError = GetModelError(current);
                current.Value.ModelErrorDeviation = GetModelErrorDeviation(current);
                current = current.Next;
            };

            var accuracy = (1 - _revenueLinkedList.ToList().Average(x => x.ModelErrorDeviation)) * 100;
            _accuracy = (int)accuracy;

            var gagr5 = (Math.Pow(_revenueLinkedList.Last.Value.Revenue / _revenueLinkedList.First.Value.Revenue, 0.2) - 1)*100;
            _gagr5 = (int)gagr5;
        }

        private double GetModelErrorDeviation(LinkedListNode<RevenueResultDTO> current)
        {
            return Math.Pow(current.Value.ModelError, 2) / Math.Pow(current.Value.Revenue, 2);
        }

        private double GetModelError(LinkedListNode<RevenueResultDTO> current)
        {
            return current.Value.Revenue - current.Value.ForecastForModelEvaluation;
        }

        private double GetForecastForModelEvaluation(LinkedListNode<RevenueResultDTO> current)
        {
            var previous = current.Previous;
            if (previous == null)
                return current.Value.CftK + current.Value.CftB;
            return previous.Value.CftK + previous.Value.CftB;
        }

        private double GetQ(LinkedListNode<RevenueResultDTO> current)
        {
            return _commonQ;
        }

        private double GetB(LinkedListNode<RevenueResultDTO> currentNode)
        {
            var previous = currentNode.Previous;
            if (previous == null)
                return 0;
            var b = _b * (currentNode.Value.CftK - previous.Value.CftK) + (1 - _b) * previous.Value.CftB;
            return b;

        }

        private double GetK(LinkedListNode<RevenueResultDTO> currentNode)
        {
            var previous = currentNode.Previous;
            if (previous == null)
                return currentNode.Value.Revenue;
            return (_k * currentNode.Value.Revenue) / _commonQ + (1 - _k) * (previous.Value.CftK + previous.Value.CftB);
        }
    }
}
