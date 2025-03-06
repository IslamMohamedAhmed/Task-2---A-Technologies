using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PaginatedClasses
{
    class PaginatedResults<T> where T : class 
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public List<T> Entities { get; set; }
    }
}
