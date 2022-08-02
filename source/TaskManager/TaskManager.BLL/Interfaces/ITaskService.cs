using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.BLL.DTO;

namespace TaskManager.BLL.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDTO> GetTaskById(Guid? id, CancellationToken cancellationToken);

        Task<IEnumerable<TaskDTO>> GetAllTasks(CancellationToken cancellationToken);

        Task EditTask(TaskDTO dto, CancellationToken cancellationToken);

        Task CreateTask(TaskDTO dto, CancellationToken cancellationToken);

        Task DeleteTask(Guid? id, CancellationToken cancellationToken);
    }
}
