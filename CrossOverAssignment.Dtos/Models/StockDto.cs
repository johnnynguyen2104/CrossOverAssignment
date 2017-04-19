using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossOverAssignment.Dtos.Models
{
    public class StockDto : BaseDto<int>
    {
        public string StockCode { get; set; }

        public string UserId { get; set; }

        public double StockPrice { get; set; }
    }
}
