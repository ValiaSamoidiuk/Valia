using System;
using Moq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using DAL.Entities;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL.Tests
{
    [TestFixture]
    public class CompanyRepositoryTest
    {
        private IRepository<Company> _companyRepository;
        private Mock<DbSet<Company>> _mockDbSet;
        private Mock<DbContext> _mockContext;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DbContext>()
                .Options;
            _mockContext = new Mock<DbContext>(opt);
            _mockDbSet = new Mock<DbSet<Company>>();

            _mockContext
                .Setup(context =>
                    context.Set<Company>(
                    ))
                .Returns(_mockDbSet.Object);

            _companyRepository = new Repository<Company>(_mockContext.Object);
        }

        [Test]
        public void Repository_CalledInsertOneTime_InsertCorrect()
        {
            // Arrange
            var expectedCompany = new Mock<Company>().Object;

            //Act
            _companyRepository.Insert(expectedCompany);

            // Assert
            _mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedCompany
                ), Times.Once());
        }

        [Test]
        public void Repository_CalledRemove_RemovedCorrect()
        {
            // Arrange
            var id = Guid.NewGuid();

            var expectedCompany = new Company { Id = id };
            _mockDbSet.Setup(mock => mock.Find(expectedCompany.Id)).Returns(expectedCompany);

            // Act

            var foundCompany = _companyRepository.GetById(id);
            _companyRepository.Remove(foundCompany);

            // Assert
            _mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedCompany.Id
                ), Times.Once());

            _mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedCompany
                ), Times.Once());
        }
    }
}