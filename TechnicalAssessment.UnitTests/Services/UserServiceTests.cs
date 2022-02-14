using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using TechnicalAssessment.Api.ApiModels;
using TechnicalAssessment.Api.BL;
using TechnicalAssessment.Api.Repositories;
using Xunit;

namespace TechnicalAssessment.UnitTests.Services
{
    public class UserServiceTests
    {
        private UserService service;
        private Mock<IUserRepository> userRepositoryMock;

        public UserServiceTests()
        {
            userRepositoryMock = new Mock<IUserRepository>();

            service = new UserService(userRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_UserNotExist_ShouldCreate()
        {
            //Arrange
            var userCreateModel = new UserCreateModel
            {
                UserName = "john_doe",
                FullName = "John Doe",
                Password = "password"
            };

            var userId = Guid.NewGuid();

            userRepositoryMock
                .Setup(x => x.CreateAsync(userCreateModel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Api.Models.User 
                {
                    Id = userId,
                    UserName = "john_doe",
                    FullName = "John Doe",
                    Password = "password"
                });

            //Act
            var user = await service.CreateAsync(userCreateModel, default);

            //Assert
            Assert.NotNull(user);
            Assert.Equal(userId, user.Id);
            Assert.Equal(userCreateModel.UserName, user.UserName);
            Assert.Equal(userCreateModel.FullName, user.FullName);
            Assert.Equal(userCreateModel.Password, user.Password);
        }
    }
}
