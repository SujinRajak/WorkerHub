using Domain.Entities;
using Domain.Interfaces;
using Mvc.Interfaces;
using Mvc.Models;
using Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerHub.Application.Extensions;

namespace Mvc.Services
{
    public class AdminService : IAdmin
    {
        private readonly IGenericUnitOfWork _uow = null;

        public AdminService(IGenericUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<vw_EmployeeInfo>> GetAllEmployeeInfo()
        {
            return await _uow.AsyncRepository<vw_EmployeeInfo>().ListAllAsync();
        }

        public async  Task<List<vw_EmployeeList>> GetAllEmployees()
        {
            return await _uow.AsyncRepository<vw_EmployeeList>().ListAllAsync();
        }

        public async Task<List<vw_HiringMangersList>> GetAllHiringManagersList()
        {
            return await _uow.AsyncRepository<vw_HiringMangersList>().ListAllAsync();
        }

        public DashboardCount GetTotalCount()
        {
            DashboardCount dashboard= new DashboardCount();
            var details= _uow.Repository<sp_GetTotalCount>().ExecQuery("sp_GetTotalCount").FirstOrDefault() ;
            details.CopyPropertiesTo(dashboard);
            return dashboard;

        }
    }
}
