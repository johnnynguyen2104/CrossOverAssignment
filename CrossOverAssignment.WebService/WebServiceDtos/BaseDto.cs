using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossOverAssignment.WebService.WebServiceDtos
{
    public class BaseDto<TKey> where TKey : struct
    {
        public TKey Id { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        public DateTime? UpdateDateTime { get; set; }
    }
}