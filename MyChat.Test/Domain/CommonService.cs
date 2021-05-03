using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyChat.Domain.Service.common;
using MyChat.Domain.Model;

namespace MyChat.Test.Domain
{
    [TestClass]
    public class CommonServiceTest
    {

        [TestMethod]
        public void It_Should_Create_A_New_Instance()
        {
            var service = new CommonService();
            Assert.IsInstanceOfType(service, typeof(CommonService));
        }

        [TestMethod]
        public void Ping_should_return_ping_response() {
            var service = new CommonService();

            var response = service.Ping();
            Assert.IsInstanceOfType(response, typeof(PingResponse));
            Assert.AreEqual(response.status, "OK");
        }
    }
}
