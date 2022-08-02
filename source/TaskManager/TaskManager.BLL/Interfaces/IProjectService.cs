using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.BLL.DTO;

namespace TaskManager.BLL.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDTO> GetProjectById(Guid? id, CancellationToken cancellationToken);

        Task<IEnumerable<ProjectDTO>> GetAllProjects(CancellationToken cancellationToken);

        void EditeEmployee(ProjectDTO dto, CancellationToken cancellationToken);

        void CreateProject(ProjectDTO dto, CancellationToken cancellationToken);

        void DeleteProject(Guid? id, CancellationToken cancellationToken);
    }
}
