using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrossOverAssignment.Business.Helpers;

namespace CrossOverAssignment.Business.Dtos
{
    public class PagingDto<TEntity>
    {

        public IList<TEntity> Items { get; set; }
        public Pager Pager { get; set; }
    }
}
