using Domain.Entities;
using Mvc.Models;
using Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Interfaces
{
    public interface IAdmin
    {
        Task<List<vw_EmployeeList>> GetAllEmployees();
        Task<List<vw_HiringMangersList>> GetAllHiringManagersList();

        Task<List<vw_EmployeeInfo>> GetAllEmployeeInfo();
        DashboardCount GetTotalCount();
    }
}
