using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossOverAssignment.WebService.WebServiceDtos
{
    public class StockWebDtos : BaseDto<int>
    {
        public string StockCode { get; set; }

        public string UserId { get; set; }

        public int StockPrice { get; set; }
    }
}