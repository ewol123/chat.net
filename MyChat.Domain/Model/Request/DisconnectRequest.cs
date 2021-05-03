using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MyChat.Domain.Model
{
    public class DisconnectRequest
    {
        [Required(ErrorMessage = "SocketId must be submitted")]
        public string socketId { get; set; }
    }
}