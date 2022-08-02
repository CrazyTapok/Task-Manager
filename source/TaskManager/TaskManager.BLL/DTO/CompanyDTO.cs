using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.BLL.DTO
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public List<ProjectDTO> Projects { get; set; }

        public List<EmployeeDTO> Employees { get; set; }
    }
}
