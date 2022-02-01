using Moq;
using System;
using TestProjectApp.Models.Data;
using TestProjectApp.Models.Repos;
using TestProjectApp.Models;
using Xunit;

namespace TestProject_unitTests.Models.Repos
{
    public class ComputerDbRepoTests
    {
        private MockRepository mockRepository;

        private Mock<ProjectDbContext> mockProjectDbContext;

        public ComputerDbRepoTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockProjectDbContext = this.mockRepository.Create<ProjectDbContext>();
        }

        private ComputerDbRepo CreateComputerDbRepo()
        {
            return new ComputerDbRepo(
                this.mockProjectDbContext.Object);
        }

        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var computerDbRepo = this.CreateComputerDbRepo();
            Computer computer = null;

            // Act
            var result = computerDbRepo.Create(
                computer);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Read_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var computerDbRepo = this.CreateComputerDbRepo();

            // Act
            var result = computerDbRepo.Read();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Read_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var computerDbRepo = this.CreateComputerDbRepo();
            int id = 0;

            // Act
            var result = computerDbRepo.Read(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var computerDbRepo = this.CreateComputerDbRepo();
            Computer computer = null;

            // Act
            computerDbRepo.Update(
                computer);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var computerDbRepo = this.CreateComputerDbRepo();
            Computer computer = null;

            // Act
            computerDbRepo.Delete(
                computer);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
