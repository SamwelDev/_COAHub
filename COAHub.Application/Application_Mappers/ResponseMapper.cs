using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Application.Application_Mappers
{
    public  class ResponseMapper <T>
    {
        public int Status { get; set; } = 0;
        public string? Message { get; set; }
        public T? Data { get; set; }
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
        public int? TotalCount { get; set; }
        public string? Description { get; set; }
        public string? Token { get; set; }
    }
}
