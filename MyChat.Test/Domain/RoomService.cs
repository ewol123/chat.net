using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyChat.Domain.Error;
using MyChat.Domain.Model;
using MyChat.Domain.Repository;
using MyChat.Domain.Service.room;

namespace MyChat.Test.Domain
{
    [TestClass]
    public class RoomServiceTest
    {
        [TestMethod]
        public void It_Should_Create_A_New_Instance()
        {
            // Setup Mocks ============================================
            var unitOfWork = new Mock<IUnitOfWork>();
            var messageRepository = new Mock<IMessageRepository>();
            var userRepository = new Mock<IUserRepository>();
            var roomRepository = new Mock<IRoomRepository>();
            // ========================================================

            var service = new RoomService(unitOfWork.Object, userRepository.Object, messageRepository.Object, roomRepository.Object);
            Assert.IsInstanceOfType(service, typeof(RoomService));
        }

        //It_Should_Leave_A_Room
        //Leave_Room_Should_Return_Error_When_User_Is_Null
        //Leave_Room_Should_Return_Error_When_Users_Room_Is_Null
        [TestMethod]
        public void It_Should_Join_A_New_Room() {
            // Setup Mocks ============================================
            var user = new User() { id = Guid.NewGuid() };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Save()).Returns(Task.CompletedTask);

            var messageRepository = new Mock<IMessageRepository>();
            messageRepository.Setup(x => x.Save(It.IsAny<Message>())).Returns(Task.FromResult(true));
            messageRepository.Setup(x => x.FindAllByRoomId(It.IsAny<Guid>())).Returns(Task.FromResult<List<Message>>(null));


            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.FindRoomOfUserById(It.IsAny<Guid>())).Returns(Task.FromResult(user));

            var roomRepository = new Mock<IRoomRepository>();
            roomRepository.Setup(x => x.FindByIdentifier(It.IsAny<Guid>())).Returns(Task.FromResult<Room>(null));
            roomRepository.Setup(x => x.Save(It.IsAny<Room>())).Returns(Task.FromResult(true));

            // ========================================================

            var request = new JoinRoomRequest();
            request.userIdentifier = user.id;
            request.roomIdentifier = Guid.NewGuid();

            var service = new RoomService(unitOfWork.Object, userRepository.Object, messageRepository.Object, roomRepository.Object);

            Task<JoinRoomResponse> response = service.JoinRoom(request);


            Assert.IsInstanceOfType(response.Result, typeof(JoinRoomResponse));
            Assert.IsNull(response.Result.error);
            Assert.IsNull(response.Result.messages);
            Assert.AreEqual(response.Result.roomIdentifier, request.roomIdentifier);
            Assert.IsInstanceOfType(response.Result.users, typeof(List<User>));
        }

        [TestMethod]
        public void Join_Room_Should_Return_Error_When_User_Is_Null()
        {
            // Setup Mocks ============================================
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Save()).Returns(Task.CompletedTask);

            var messageRepository = new Mock<IMessageRepository>();
            messageRepository.Setup(x => x.Save(It.IsAny<Message>())).Returns(Task.FromResult(true));
            messageRepository.Setup(x => x.FindAllByRoomId(It.IsAny<Guid>())).Returns(Task.FromResult<List<Message>>(null));


            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.FindRoomOfUserById(It.IsAny<Guid>())).Returns(Task.FromResult<User>(null));

            var roomRepository = new Mock<IRoomRepository>();
            roomRepository.Setup(x => x.FindByIdentifier(It.IsAny<Guid>())).Returns(Task.FromResult<Room>(null));
            roomRepository.Setup(x => x.Save(It.IsAny<Room>())).Returns(Task.FromResult(true));
            // ========================================================


            var request = new JoinRoomRequest();
            request.userIdentifier = Guid.NewGuid();
            request.roomIdentifier = Guid.NewGuid();

            var service = new RoomService(unitOfWork.Object, userRepository.Object, messageRepository.Object, roomRepository.Object);

            try
            {
                Task<JoinRoomResponse> response = service.JoinRoom(request);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ApplicationError));
            }
        }

        [TestMethod]
        public void Join_Room_Should_Return_Error_When_Room_Is_Null()
        {
            // Setup Mocks ============================================
            var user = new User() { id = Guid.NewGuid() };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Save()).Returns(Task.CompletedTask);

            var messageRepository = new Mock<IMessageRepository>();
            messageRepository.Setup(x => x.Save(It.IsAny<Message>())).Returns(Task.FromResult(true));
            messageRepository.Setup(x => x.FindAllByRoomId(It.IsAny<Guid>())).Returns(Task.FromResult<List<Message>>(null));


            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.FindRoomOfUserById(It.IsAny<Guid>())).Returns(Task.FromResult(user));

            var roomRepository = new Mock<IRoomRepository>();
            roomRepository.Setup(x => x.FindByIdentifier(It.IsAny<Guid>())).Returns(Task.FromResult<Room>(null));
            roomRepository.Setup(x => x.Save(It.IsAny<Room>())).Returns(Task.FromResult(true));
            // ========================================================


            var request = new JoinRoomRequest();
            request.userIdentifier = user.id;
            request.roomIdentifier = Guid.NewGuid();

            var service = new RoomService(unitOfWork.Object, userRepository.Object, messageRepository.Object, roomRepository.Object);

            try
            {
                Task<JoinRoomResponse> response = service.JoinRoom(request);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ApplicationError));
            }
        }
    }
}
