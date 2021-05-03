/*
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyChat.Domain.Model;
using MyChat.Domain.Service.user;
using MyChat.Server.Repository.user;
namespace MyChat.Test
{
    [TestClass]
    public class NonQueryTests2
    {
        [TestMethod]
        public void Create_user_creates_a_user()
        {
            var userService = new Mock<UserService>();

            CreateUserRequest request = new CreateUserRequest() { name = "Test", socketId = "socketId" };

            var basd = userService.Object.CreateUser(request);

            userService.Verify(u => u.CreateUser(It.IsAny<CreateUserRequest>()), Times.Once());


        }
    }
}

 */