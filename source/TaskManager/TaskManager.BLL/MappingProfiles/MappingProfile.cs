using AutoMapper;
using TaskManager.BLL.DTO;
using TaskManager.DAL.Entities;

namespace TaskManager.BLL.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();

            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();

            CreateMap<Task, TaskDTO>();
            CreateMap<TaskDTO, Task>();

            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();
        }
    }
}
