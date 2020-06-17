using System;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyDTO> GetCompanyAsync(Guid id);
        Task<CompanyDTO> AddCompanyAsync(CompanyDTO company);
        Task RemoveCompanyAsync(Guid id);
    }
}