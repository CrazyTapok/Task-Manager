﻿using AutoMapper;
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
    public class CompanyService : ICompanyService
    {

        private readonly ApplicationContext _context;

        private readonly IMapper _mapper;

        public CompanyService(ApplicationContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async void CreateComany(CompanyDTO dto, CancellationToken cancellationToken)
        {
            Company company = await _context.Companies.FirstOrDefaultAsync(p => p.Title == dto.Title, cancellationToken);

            if (company != null)
                throw new ValidationException("A company with that name already exists", "");

            _context.Companies.Add(_mapper.Map<Company>(dto));
            
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async void DeleteCompany(Guid? id, CancellationToken cancellationToken)
        {
            if (id.HasValue)
                throw new ValidationException("Company ID not set", "");

            Company company = await _context.Companies.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            if (company == null)
                throw new ValidationException("Company not found.", "");

            _context.Companies.Remove(company);
            
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async void EditeCompany(CompanyDTO dto, CancellationToken cancellationToken)
        {
            _context.Companies.Update(_mapper.Map<Company>(dto));
            
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<CompanyDTO>> GetAllCompanies(CancellationToken cancellationToken)
        {
            var companies = await _context.Companies
                .Include(p => p.Projects)
                .Include(e => e.Employees)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<CompanyDTO>>(companies);
        }

        public async Task<CompanyDTO> GetCompanyById(Guid? id, CancellationToken cancellationToken)
        {
            if (!id.HasValue)
                throw new ValidationException("Company ID not set", "");
            
            Company company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            return _mapper.Map<CompanyDTO>(company);
        }
    }
}
