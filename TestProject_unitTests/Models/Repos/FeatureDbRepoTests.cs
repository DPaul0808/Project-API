using Moq;
using System;
using TestProjectApp.Models.Data;
using TestProjectApp.Models.Repos;
using TestProjectApp.Models;
using Xunit;

namespace TestProject_unitTests.Models.Repos
{
    public class FeatureDbRepoTests
    {
        private MockRepository mockRepository;

        private Mock<ProjectDbContext> mockProjectDbContext;

        public FeatureDbRepoTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockProjectDbContext = this.mockRepository.Create<ProjectDbContext>();
        }

        private FeatureDbRepo CreateFeatureDbRepo()
        {
            return new FeatureDbRepo(
                this.mockProjectDbContext.Object);
        }

        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var featureDbRepo = this.CreateFeatureDbRepo();
            Feature feature = null;

            // Act
            var result = featureDbRepo.Create(
                feature);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Read_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var featureDbRepo = this.CreateFeatureDbRepo();

            // Act
            var result = featureDbRepo.Read();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Read_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var featureDbRepo = this.CreateFeatureDbRepo();
            int id = 0;

            // Act
            var result = featureDbRepo.Read(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var featureDbRepo = this.CreateFeatureDbRepo();
            Feature feature = null;

            // Act
            featureDbRepo.Update(
                feature);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var featureDbRepo = this.CreateFeatureDbRepo();
            Feature feature = null;

            // Act
            featureDbRepo.Delete(
                feature);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
