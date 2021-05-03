using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyChat.Domain.Error;
using MyChat.Domain.Model;
using MyChat.Domain.Repository;
using MyChat.Domain.Service.message;
using MyChat.Server.Infrastructure;
using MyChat.Server.Repository;
using MyChat.Server.Repository.message;
using MyChat.Server.Repository.user;
using System;
using System.Threading.Tasks;

namespace MyChat.Test.Domain
{
    [TestClass]
    public class MessageServiceTest
    {
        [TestMethod]
        public void It_Should_Create_A_New_Instance()
        {
            // Setup Mocks ============================================
            var unitOfWork = new Mock<IUnitOfWork>();
            var messageRepository = new Mock<IMessageRepository>();
            var userRepository = new Mock<IUserRepository>();
            // ========================================================

            var service = new MessageService(unitOfWork.Object, userRepository.Object, messageRepository.Object);
            Assert.IsInstanceOfType(service, typeof(MessageService));
        }

        [TestMethod]
        public void It_Should_Create_A_Message()
        {

            // Setup Mocks ============================================
            var user = new User() { id = Guid.NewGuid(), room = new Room() { identifier = Guid.NewGuid() } };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Save()).Returns(Task.CompletedTask);

            var messageRepository = new Mock<IMessageRepository>();
            messageRepository.Setup(x => x.Save(It.IsAny<Message>())).Returns(Task.FromResult(true));

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.FindRoomOfUserById(It.IsAny<Guid>())).Returns(Task.FromResult(user));
            // ========================================================

            var request = new CreateMessageRequest();
            request.userIdentifier = user.id;
            request.text = "hello world";

            var service = new MessageService(unitOfWork.Object, userRepository.Object, messageRepository.Object);

            Task<CreateMessageResponse> response = service.CreateMessage(request);

            
            Assert.IsInstanceOfType(response.Result, typeof(CreateMessageResponse));
            Assert.IsNull(response.Result.error);
            Assert.AreEqual(response.Result.roomIdentifier, user.room.identifier);
            Assert.AreEqual(response.Result.message.text,request.text);
        }

        [TestMethod]
        public void It_Should_Return_Error_When_User_Is_Null() {


            // Setup Mocks ============================================
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Save()).Returns(Task.CompletedTask);

            var messageRepository = new Mock<IMessageRepository>();
            messageRepository.Setup(x => x.Save(It.IsAny<Message>())).Returns(Task.FromResult(true));

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.FindRoomOfUserById(It.IsAny<Guid>())).Returns(Task.FromResult<User>(null));
            // ========================================================


            var request = new CreateMessageRequest();
            request.userIdentifier = Guid.NewGuid();
            request.text = "hello world";

            var service = new MessageService(unitOfWork.Object, userRepository.Object, messageRepository.Object);

            try
            {
                Task<CreateMessageResponse> response = service.CreateMessage(request);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ApplicationError));
            }
        }

        [TestMethod]
        public void It_Should_Return_Error_When_Users_Room_Is_Null()
        {
            // Setup Mocks ============================================
            var user = new User() { id = Guid.NewGuid() };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Save()).Returns(Task.CompletedTask);

            var messageRepository = new Mock<IMessageRepository>();
            messageRepository.Setup(x => x.Save(It.IsAny<Message>())).Returns(Task.FromResult(true));

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.FindRoomOfUserById(It.IsAny<Guid>())).Returns(Task.FromResult(user));
            // ========================================================

            var request = new CreateMessageRequest();
            request.userIdentifier = user.id;
            request.text = "hello world";

            var service = new MessageService(unitOfWork.Object, userRepository.Object, messageRepository.Object);

            try
            {
                Task<CreateMessageResponse> response = service.CreateMessage(request);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ApplicationError));

            }
        }
    }
}
