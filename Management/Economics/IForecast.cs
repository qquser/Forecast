using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Economics
{
    public interface IForecast
    {
        int Accuracy { get; }
        int Gagr5 { get; }
        LinkedList<RevenueResultDTO> RevenueLinkedList { get; }

    }
}
 