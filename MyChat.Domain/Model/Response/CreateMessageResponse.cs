using System;
using System.Collections.Generic;
using System.Text;
using MyChat.Domain.Error;
namespace MyChat.Domain.Model
{
    public class CreateMessageResponse: IResponse
    {
        public Message message{ get; set; }

        public Guid roomIdentifier { get; set; }

        public IEnumerable<ApplicationError> error { get; set; }
    }
}
