using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CrossOverAssignment.Business.Dtos
{
    public class BaseDto<TKey> where TKey : struct
    {
        public TKey Id { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        public DateTime? UpdateDateTime { get; set; }
    }
}
