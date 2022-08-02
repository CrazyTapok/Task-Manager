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
    public class EmployeeService : IEmployeeService
    {

        private readonly ApplicationContext _context;

        private readonly IMapper _mapper;

        public EmployeeService(ApplicationContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }


        public async void CreateEmployee(EmployeeDTO dto, CancellationToken cancellationToken)
        {
            Employee employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == dto.Email, cancellationToken);

            if (employee != null)
                throw new ValidationException("An employee with that Email already exists", "");

            _context.Employees.Add(_mapper.Map<Employee>(dto));
           
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async void DeleteEmployee(Guid? id, CancellationToken cancellationToken)
        {
            if (id.HasValue)
                throw new ValidationException("Employee ID not set", "");

            Employee employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

            if (employee == null)
                throw new ValidationException("Employee not found.", "");

            _context.Employees.Remove(employee);
           
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async void EditeEmployee(EmployeeDTO dto, CancellationToken cancellationToken)
        {
            _context.Employees.Update(_mapper.Map<Employee>(dto));
            
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees(CancellationToken cancellationToken)
        {
            var employees = await _context.Employees
                .Include(p => p.Projects)
                .Include(c => c.Company)
                .Include(t => t.Tasks)
                .Include(r => r.Role)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO> GetEmployeeById(Guid? id, CancellationToken cancellationToken)
        {
            if (!id.HasValue)
                throw new ValidationException("Employee ID not set", "");

            Employee employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

            return _mapper.Map<EmployeeDTO>(employee);
        }
    }
}
