using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.BLL.DTO
{
    public class ProjectDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid ManagerId { get; set; }

        public Guid CompanyId { get; set; }

    }
}
