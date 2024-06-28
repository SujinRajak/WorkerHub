using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class sp_GetTotalCount
    {
        public int HighringMangerCount { get; set; }
        public int EmployeeCount { get; set; }
        public int TotalUsers { get; set; }
        public int TotalRoles { get; set; }
    }
}
