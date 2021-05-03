using System;
using System.Collections.Generic;
using System.Text;

namespace MyChat.Domain.Model
{
    public class Room
    {
        public Guid id { get; set; }
        public Guid identifier { get; set; }
        public List<User> users { get; set; }

        public List<Message> messages { get; set; }
    }
}