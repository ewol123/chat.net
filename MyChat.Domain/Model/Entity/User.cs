using System;
using System.Collections.Generic;
using System.Text;

namespace MyChat.Domain.Model
{
    public class User
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string socketId { get; set; }
        public Room room { get; set; }
        public List<Message> messages { get; set; }

    }
}
