using System;
using System.Collections.Generic;
using System.Text;

namespace MyChat.Domain.Model
{
    public class Message
    {
        public Guid id { get; set; }
        public string text { get; set; }
        public DateTime stamp { get; set; }
        public User user { get; set; }
        public Room room { get; set; }

    }
}