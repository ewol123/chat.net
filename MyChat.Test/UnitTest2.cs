/*
 using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyChat.Domain.Model;
using MyChat.Server.Infrastructure;
using MyChat.Server.Repository.user;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyChat.Server.Hub;
using MyChat.Domain.Service.user;
using MyChat.Domain.Service.common;
using MyChat.Domain.Service.chime;
using MyChat.Domain.Service.message;
using MyChat.Domain.Service.room;
using Microsoft.AspNetCore.SignalR;
namespace MyChat.Test
{
    [TestClass]
    class UnitTest2
    {
        [TestMethod]
        public void Ping_checks_service_status()
        {
            var mockLogger = new Mock<ILogger<ChatHub>>();
            ILogger<ChatHub> logger = mockLogger.Object;

            var userService = new Mock<IUserService>();
            var commonService = new Mock<ICommonService>();
            var chimeService = new Mock<IChimeService>();
            var messageService = new Mock<IMessageService>();
            var roomService = new Mock<IRoomService>();

            var hub = new ChatHub(
                logger,
                userService.Object,
                commonService.Object,
                chimeService.Object,
                messageService.Object,
                roomService.Object);
       //     var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
            var all = new Mock<IChatClient>();
         //   hub.Clients = (IHubCallerClients<IChatClient>)mockClients.Object;

            all.Setup(m => m.Pong(It.IsAny<PingResponse>())).Verifiable();

        //    mockClients.Setup(m => m.All).Returns(all.Object);
            hub.Ping();
            all.VerifyAll();
        }

    }
}

 */