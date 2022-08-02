using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.BLL.DTO;

namespace TaskManager.BLL.Interfaces
{
    public interface IRoleService
    {
        Task<RoleDTO> GetRoleById(Guid? id, CancellationToken cancellationToken);

        Task<IEnumerable<RoleDTO>> GetAllRoles(CancellationToken cancellationToken);
    }
}
