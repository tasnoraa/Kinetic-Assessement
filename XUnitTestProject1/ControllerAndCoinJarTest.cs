using KineticAssessment.Controllers;
using KineticAssessment.Interface;
using KineticAssessment.Models;
using KineticAssessment.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xunit;

namespace AssessmentUnitTest
{
    public class ControllerAndCoinJarTest
    {
        [Fact]
        public void GetTotalAmountAPICallTest()
        {
            // Arrange
            var mockRepo = new Mock<ICoinJar>();
            mockRepo.Setup(repo => repo.GetTotalAmount())
                .Returns(0);
            var controller = new ValuesController(mockRepo.Object);

            var result =  controller.Get();
            // Act
            Assert.Equal("$0", result.Value);
        }

        [Fact]
        public void RestAPICallTest()
        {
            // Arrange
            var mockRepo = new Mock<ICoinJar>();
            mockRepo.Setup(repo => repo.Reset())
                .Verifiable();
        }

        [Fact]
        public void AddCoinAPICallTest()
        {
            var mockRepo = new Mock<ICoinJar>();
            mockRepo.Setup(repo => repo.AddCoin(It.IsAny<Coin>()))
                .Verifiable();
        }


        [Fact]
        public void GetTotalAmountRepoTest()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();

            var mockRepo = new Mock<ICoinJar>();
            mockRepo.Setup(x => x.GetTotalAmount())
                .Returns(30);

            var mock = mockRepo.Object;
            var result = mock.GetTotalAmount();

            Assert.Equal(30, mock.GetTotalAmount());
        }

        [Fact]
        public void AddCoinRepoTest()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();

            var mockRepo = new Mock<ICoinJar>();
            mockRepo.Setup(x => x.AddCoin(It.IsAny<Coin>()))
                .Verifiable();
        }

        [Fact]
        public void ResetRepoTest()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();

            var mockRepo = new Mock<ICoinJar>();
            mockRepo.Setup(x => x.Reset())
                .Verifiable();
        }
    }
}
