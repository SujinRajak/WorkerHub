using AutoMapper;
using Domain.Entities;
using Mvc.Models;

namespace Mvc.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<sp_GetTotalCount, DashboardCount>().ReverseMap();
        }
    }
}
