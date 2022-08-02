using AutoMapper;
using TaskManager.BLL.DTO;
using TaskManager.DAL.Entities;

namespace TaskManager.BLL.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();

            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            CreateMap<Project, ProjectDTO>().ReverseMap();

            CreateMap<Task, TaskDTO>().ReverseMap();

            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
