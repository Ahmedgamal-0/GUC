using GUC.Entities;
using GUC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUC.Services
{
    public class GucRepo : IGucRepo
    {
        GucDBContext _GucDBContext;
        public GucRepo(GucDBContext GucDBContext)
        {
            _GucDBContext = GucDBContext;
        }
        public IEnumerable<ListDto> GetList()
        {
            var Sales = _GucDBContext.Sales.Where(o => o.Gender == "female").ToList();
            var ListDto = new List<ListDto>();
            foreach(var Saler in Sales)
            {
                var SalerData = new ListDto();
                double TotalAmout = 0;
                var LastOrders = _GucDBContext.Orders.Where(o => o.SalesId == Saler.Id).ToList();
                for(int i = 0; i < LastOrders.Count; i++)
                {
                    TotalAmout += LastOrders.ElementAt(i).PurchaseAmount;
                }
                var LastOrderDate = LastOrders.Last().OrderDate;
                SalerData.LastOrderDate = LastOrderDate;
                SalerData.TotalAmount = TotalAmout;
                SalerData.SalesName = Saler.SalesName;
                ListDto.Add(SalerData);
            }
            return ListDto;
        }
    }
}
