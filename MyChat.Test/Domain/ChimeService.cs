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
using MyChat.Domain.Service.chime;

namespace MyChat.Test.Domain
{

    [TestClass]
    public class ChimeServiceTest
    {
        [TestMethod]
        public void It_Should_Create_A_New_Instance()
        {
            // Setup Mocks ============================================
            var unitOfWork = new Mock<IUnitOfWork>();
            var userRepository = new Mock<IUserRepository>();
            // ========================================================

            var service = new ChimeService(unitOfWork.Object, userRepository.Object);
            Assert.IsInstanceOfType(service, typeof(ChimeService));
        }

        [TestMethod]
        public void It_Should_Create_A_Chime_Meeting() {

            // Setup Mocks ============================================
            var user = new User() { id = Guid.NewGuid(), room = new Room() { identifier = Guid.NewGuid() } };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Save()).Returns(Task.CompletedTask);

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.FindById(It.IsAny<Guid>())).Returns(Task.FromResult(user));
            // ========================================================


            var request = new CreateChimeMeetingRequest();
            request.userIdentifier = user.id;

            var service = new ChimeService(unitOfWork.Object, userRepository.Object);

            Task<CreateChimeMeetingResponse> response = service.CreateChimeMeeting(request);

            Assert.IsInstanceOfType(response.Result, typeof(CreateChimeMeetingResponse));
            Assert.IsNull(response.Result.error);
            Assert.IsInstanceOfType(response.Result.attendeeResponse, typeof(Amazon.Chime.Model.CreateAttendeeResponse));
            Assert.IsInstanceOfType(response.Result.meetingResponse, typeof(Amazon.Chime.Model.CreateMeetingResponse));

        }

        [TestMethod]
        public void Create_Chime_Meeting_Should_Return_Error_When_User_Is_Null()
        {
            // Setup Mocks ============================================
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Save()).Returns(Task.CompletedTask);

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.FindById(It.IsAny<Guid>())).Returns(Task.FromResult<User>(null));
            // ========================================================


            var request = new CreateChimeMeetingRequest();
            request.userIdentifier = Guid.NewGuid();

            var service = new ChimeService(unitOfWork.Object, userRepository.Object);

            try
            {
                Task<CreateChimeMeetingResponse> response = service.CreateChimeMeeting(request);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ApplicationError));
            }

        }

    }
}
