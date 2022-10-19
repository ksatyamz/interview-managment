using AutoMapper;
using EmployeeApi.Models.Domain;
using EmployeeApi.Models.Dto;

namespace EmployeeApi.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
