using System;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Services;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork.Interfaces;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{
    public class CompanyServiceTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;

        [SetUp]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [Test]
        public void CompanyServiceCtor_NullConstructionParams_ExceptionThrows()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new CompanyService(null));
        }

        [Test]
        public void CompanyServiceRemoveRegion_UserIsUser_ThrowMethodAccessException()
        {
            // Arrange
            var user = new User(Guid.NewGuid(), Guid.NewGuid().ToString());
            Authorization.SetUser(user);

            ICompanyService companyService = new CompanyService(_mockUnitOfWork.Object);

            // Act

            // Assert
            Assert.ThrowsAsync<MethodAccessException>(() => companyService.RemoveCompanyAsync(Guid.NewGuid()));
        }

        [Test]
        public async Task GetCompanyCompanyFromDalCorrectMappingToCompanyDTO()
        {
            // Arrange
            var user = new Administrator(Guid.NewGuid(), Guid.NewGuid().ToString());
            Authorization.SetUser(user);

            var itemId = Guid.NewGuid();
            var companyService = GetPoliceDepartmentService(itemId);

            // Act
            var company = await companyService.GetCompanyAsync(itemId);

            // Assert
            Assert.True(
                company.Id == itemId
                && company.Name == "testName"
                && company.Employees == 10
                && company.Capitalization == 1000000
            );
        }

        private ICompanyService GetPoliceDepartmentService(Guid itemId)
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedCompany = new Company()
            {
                Id = itemId,
                Name = "testName",
                Employees = 10,
                Capitalization = 1000000
            };
            var mockDbSet = new Mock<IRepository<Company>>();

            mockDbSet.Setup(mock => mock.GetByIdAsync(itemId)).ReturnsAsync(expectedCompany);

            mockContext
                .Setup(context =>
                    context.Repository<Company>())
                .Returns(mockDbSet.Object);
            mockContext.Setup(mock => mock.GetByIdAsync<Company>(itemId)).ReturnsAsync(expectedCompany);

            ICompanyService companyService = new CompanyService(mockContext.Object);

            return companyService;
        }

    }
}