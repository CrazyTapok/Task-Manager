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

        void EditeCompany(CompanyDTO dto, CancellationToken cancellationToken);

        void CreateComany(CompanyDTO dto, CancellationToken cancellationToken);

        void DeleteCompany(Guid? id, CancellationToken cancellationToken);
    }
}
