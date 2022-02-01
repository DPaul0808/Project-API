using Moq;
using System;
using TestProjectApp.Models.Data;
using TestProjectApp.Models.Repos;
using TestProjectApp.Models;
using Xunit;

namespace TestProject_unitTests.Models.Repos
{
    public class ComponentDbRepoTests
    {
        private MockRepository mockRepository;

        private Mock<ProjectDbContext> mockProjectDbContext;

        public ComponentDbRepoTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockProjectDbContext = this.mockRepository.Create<ProjectDbContext>();
        }

        private ComponentDbRepo CreateComponentDbRepo()
        {
            return new ComponentDbRepo(
                this.mockProjectDbContext.Object);
        }

        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var componentDbRepo = this.CreateComponentDbRepo();
            Component component = null;

            // Act
            var result = componentDbRepo.Create(
                component);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Read_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var componentDbRepo = this.CreateComponentDbRepo();

            // Act
            var result = componentDbRepo.Read();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Read_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var componentDbRepo = this.CreateComponentDbRepo();
            int id = 0;

            // Act
            var result = componentDbRepo.Read(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var componentDbRepo = this.CreateComponentDbRepo();
            Component component = null;

            // Act
            componentDbRepo.Update(
                component);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var componentDbRepo = this.CreateComponentDbRepo();
            Component component = null;

            // Act
            componentDbRepo.Delete(
                component);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
