using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskManager.BLL.DTO
{
    public class ProjectDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid ManagerId { get; set; }

        public Guid CompanyId { get; set; }
        public CompanyDTO Company { get; set; }

        public List<EmployeeDTO> Employees { get; set; }

        public List<TaskDTO> Tasks { get; set; }

    }
}
