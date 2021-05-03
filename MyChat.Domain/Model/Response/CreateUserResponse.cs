using System;
using System.Collections.Generic;
using System.Text;
using MyChat.Domain.Error;
namespace MyChat.Domain.Model
{
    public class CreateUserResponse: IResponse
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public IEnumerable<ApplicationError> error { get; set; }

    }
}
