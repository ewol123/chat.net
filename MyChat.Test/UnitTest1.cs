/*
 using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyChat.Domain.Model;
using MyChat.Server.Infrastructure;
using MyChat.Server.Repository.user;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MyChat.Test
{
    [TestClass]
    public class NonQueryTests
    {
        [TestMethod]
        public void Save_saves_a_user_via_context()
        {
            var mockSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<AppDbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var mockLogger = new Mock<ILogger<UserRepository>>();
            ILogger<UserRepository> logger = mockLogger.Object;

            var repo = new UserRepository(mockContext.Object, logger);

            User user = new User() { id = new System.Guid(), name = "Test", socketId = "socketId" };

            repo.Save(user);

            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}

 
 */