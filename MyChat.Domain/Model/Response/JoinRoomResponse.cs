using System;
using System.Collections.Generic;
using System.Text;
using MyChat.Domain.Error;
namespace MyChat.Domain.Model
{
    public class JoinRoomResponse: IResponse
    {
        public Guid roomIdentifier { get; set; }
        public IEnumerable<User> users { get; set; }
        public IEnumerable<Message> messages { get; set; }
        public IEnumerable<ApplicationError> error { get; set; }
    }
}
