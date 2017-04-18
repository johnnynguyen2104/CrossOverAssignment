using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossOverAssignment.DAL.DomainModels
{
    public class BaseEntity<TKey> where TKey : struct 
    {
        public TKey Id { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        public DateTime? UpdateDateTime { get; set; }
    }
}
