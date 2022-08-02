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
using Task = TaskManager.DAL.Entities.Task;

namespace TaskManager.BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationContext _context;

        private readonly IMapper _mapper;

        public TaskService(ApplicationContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }


        public async void CreateTask(TaskDTO dto, CancellationToken cancellationToken)
        {
            Task task = await _context.Tasks.FirstOrDefaultAsync(t => t.Title == dto.Title, cancellationToken);

            if (task != null)
                throw new ValidationException("A task with that name already exists", "");

            _context.Tasks.Add(_mapper.Map<Task>(dto));
           
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async void DeleteTask(Guid? id, CancellationToken cancellationToken)
        {
            if (id.HasValue)
                throw new ValidationException("Task ID not set", "");

            Task task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

            if (task == null)
                throw new ValidationException("Task not found.", "");

            _context.Tasks.Remove(task);
           
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async void EditeTask(TaskDTO dto, CancellationToken cancellationToken)
        {
            _context.Tasks.Update(_mapper.Map<Task>(dto));
           
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasks(CancellationToken cancellationToken)
        {
            var tasks = await _context.Tasks
                .Include(c => c.CreateEmployee)
                .Include(a => a.AssinedEmployee)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
        }

        public async Task<TaskDTO> GetTaskById(Guid? id, CancellationToken cancellationToken)
        {
            if (!id.HasValue)
                throw new ValidationException("Task ID not set", "");

            Task task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

            return _mapper.Map<TaskDTO>(task);
        }
    }
}
