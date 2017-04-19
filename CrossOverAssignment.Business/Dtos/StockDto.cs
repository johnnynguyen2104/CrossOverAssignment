using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossOverAssignment.Business.Dtos
{
    public class StockDto : BaseDto<int>
    {
        public string StockCode { get; set; }

        public string UserId { get; set; }
    }
}
