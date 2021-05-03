using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MyChat.Domain.Model
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "SocketId must be submitted")]
        public string socketId { get; set; }

        [Required(ErrorMessage = "Name must be submitted"), MinLength(1), MaxLength(255)]
        public string name { get; set; }
    }
}

