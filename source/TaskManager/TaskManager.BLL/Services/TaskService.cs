using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.BLL.DTO;
using TaskManager.BLL.Infrastructure;
using TaskManager.BLL.Interfaces;
using TaskManager.DAL.EF;

namespace TaskManager.BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationContext _context;

        private readonly IMapper _mapper;

        public TaskService(ApplicationContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }


        public async Task CreateTask(TaskDTO dto, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Title == dto.Title, cancellationToken);

            if (task != null)
                throw new ValidationException("A task with that name already exists", "");

            _context.Tasks.Add(_mapper.Map<DAL.Entities.Task>(dto));
           
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteTask(Guid? id, CancellationToken cancellationToken)
        {
            if (id.HasValue)
                throw new ValidationException("Task ID not set", "");

            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

            if (task == null)
                throw new ValidationException("Task not found.", "");

            _context.Tasks.Remove(task);
           
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task EditTask(TaskDTO dto, CancellationToken cancellationToken)
        {
            _context.Tasks.Update(_mapper.Map<DAL.Entities.Task>(dto));
           
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasks(CancellationToken cancellationToken)
        {
            return await _mapper.ProjectTo<TaskDTO>(_context.Tasks).ToListAsync(cancellationToken);
        }

        public async Task<TaskDTO> GetTaskById(Guid? id, CancellationToken cancellationToken)
        {
            if (!id.HasValue)
                throw new ValidationException("Task ID not set", "");

            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

            return _mapper.Map<TaskDTO>(task);
        }
    }
}
