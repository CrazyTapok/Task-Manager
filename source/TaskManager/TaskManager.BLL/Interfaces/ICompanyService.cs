using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.BLL.DTO;

namespace TaskManager.BLL.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyDTO> GetCompanyById(Guid? id, CancellationToken cancellationToken);

        Task<IEnumerable<CompanyDTO>> GetAllCompanies(CancellationToken cancellationToken);

        Task EditCompany(CompanyDTO dto, CancellationToken cancellationToken);

        Task CreateComany(CompanyDTO dto, CancellationToken cancellationToken);

        Task DeleteCompany(Guid? id, CancellationToken cancellationToken);
    }
}
