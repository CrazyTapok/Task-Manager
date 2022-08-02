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

        Task EditEmployee(EmployeeDTO dto, CancellationToken cancellationToken);

        Task CreateEmployee(EmployeeDTO dto, CancellationToken cancellationToken);

        Task DeleteEmployee(Guid? id, CancellationToken cancellationToken);
    }
}

