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
using TaskManager.DAL.Entities;

namespace TaskManager.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationContext _context;

        private readonly IMapper _mapper;

        public ProjectService(ApplicationContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }


        public async void CreateProject(ProjectDTO dto, CancellationToken cancellationToken)
        {
            Project project = await _context.Projects.FirstOrDefaultAsync(p => p.Title == dto.Title, cancellationToken);

            if (project != null)
                throw new ValidationException("A project with that name already exists", "");

            _context.Projects.Add(_mapper.Map<Project>(dto));
            
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async void DeleteProject(Guid? id, CancellationToken cancellationToken)
        {
            if (id.HasValue)
                throw new ValidationException("Project ID not set", "");

            Project project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            if (project == null)
                throw new ValidationException("Project not found.", "");

            _context.Projects.Remove(project);
            
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async void EditeEmployee(ProjectDTO dto, CancellationToken cancellationToken)
        {
            _context.Projects.Update(_mapper.Map<Project>(dto));
            
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjects(CancellationToken cancellationToken)
        {
            var projects = await _context.Projects
               .Include(t => t.Tasks)
               .Include(e => e.Employees)
               .Include(m => m.ManagerId)
               .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProjectDTO>>(projects);
        }

        public async Task<ProjectDTO> GetProjectById(Guid? id, CancellationToken cancellationToken)
        {
            if (!id.HasValue)
                throw new ValidationException("Project ID not set", "");

            Project project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            return _mapper.Map<ProjectDTO>(project);
        }
    }
}
