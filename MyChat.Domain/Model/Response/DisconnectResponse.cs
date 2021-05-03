using System;
using System.Collections.Generic;
using System.Text;
using MyChat.Domain.Error;
namespace MyChat.Domain.Model
{
    public class DisconnectResponse: IResponse
    {
        public Guid roomIdentifier { get; set; }
        public IEnumerable<User> users { get; set; }
        public IEnumerable<ApplicationError> error { get; set; }

    }
}
