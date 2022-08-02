using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.BLL.DTO
{
    public class TaskDTO
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }
        public ProjectDTO Project { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public Guid CreateEmployeeId { get; set; }
        public EmployeeDTO CreateEmployee { get; set; }

        public Guid AssinedEmployeeId { get; set; }
        public EmployeeDTO AssinedEmployee { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public byte Image { get; set; }
    }
}
