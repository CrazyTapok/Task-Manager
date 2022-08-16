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
    public class RoleService : IRoleService
    {
        private readonly ApplicationContext _context;

        private readonly IMapper _mapper;

        public RoleService(ApplicationContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }


        public async Task<IEnumerable<RoleDTO>> GetAllRoles(CancellationToken cancellationToken)
        {
            return await _mapper.ProjectTo<RoleDTO>(_context.Roles).ToListAsync(cancellationToken);
        }

        public async Task<RoleDTO> GetRoleById(Guid? id, CancellationToken cancellationToken)
        {
            if (!id.HasValue)
                throw new ValidationException("Role ID not set", "");

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

            return _mapper.Map<RoleDTO>(role);
        }
    }
}
