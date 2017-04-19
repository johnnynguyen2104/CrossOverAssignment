using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossOverAssignment.DAL.DomainModels
{
    public class Stock : BaseEntity<int>
    {
        public string StockCode { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
