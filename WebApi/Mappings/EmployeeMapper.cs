using AutoMapper;
using WebApi.DTO;
using WebApi.Models;

namespace WebApi.Mappings
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<EmployeeModel, EmployeeDTO>().ReverseMap();
        }
    }
}
