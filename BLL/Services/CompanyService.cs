using System;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork.Interfaces;

namespace BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(
                              nameof(unitOfWork));
        }

        public async Task<CompanyDTO> GetCompanyAsync(Guid id)
        {
            var company = await GetCompanyByIdAsync(id);

            return new CompanyDTO()
            {
                Id = company.Id,
                Employees = company.Employees,
                Name = company.Name,
                Capitalization = company.Capitalization
            };
        }

        public async Task<CompanyDTO> AddCompanyAsync(CompanyDTO company)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var entity = new Company()
            {
                Employees = company.Employees,
                Name = company.Name,
                Capitalization = company.Capitalization
            };
            var result = await _unitOfWork.InsertAsync(entity);
            await _unitOfWork.CommitAsync();

            return new CompanyDTO()
            {
                Id = result.Id,
                Employees = result.Employees,
                Name = result.Name,
                Capitalization = result.Capitalization
            };
        }

        public async Task RemoveCompanyAsync(Guid id)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var company = await GetCompanyByIdAsync(id);
            _unitOfWork.Remove(company);
            await _unitOfWork.CommitAsync();
        }

        private async Task<Company> GetCompanyByIdAsync(Guid id)
        {
            var company = await _unitOfWork.GetByIdAsync<Company>(id);

            if (company == null)
            {
                throw new Exception("Company not found");
            }

            return company;
        }
    }
}