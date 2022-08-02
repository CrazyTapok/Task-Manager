using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.BLL.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid CompanyId { get; set; }
        public CompanyDTO Company { get; set; }

        public List<ProjectDTO> Projects { get; set; }

        public List<TaskDTO> Tasks { get; set; }

        public Guid RoleId { get; set; }
        public RoleDTO Role { get; set; }

    }
}
