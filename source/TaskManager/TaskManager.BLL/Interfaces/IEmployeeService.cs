using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.BLL.DTO;

namespace TaskManager.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetEmployeeById(Guid? id, CancellationToken cancellationToken);

        Task<IEnumerable<EmployeeDTO>> GetAllEmployees(CancellationToken cancellationToken);

        void EditeEmployee(EmployeeDTO dto, CancellationToken cancellationToken);

        void CreateEmployee(EmployeeDTO dto, CancellationToken cancellationToken);

        void DeleteEmployee(Guid? id, CancellationToken cancellationToken);
    }
}

