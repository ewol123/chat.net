using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MyChat.Domain.Model
{
    public class JoinRoomRequest
    {
        [Required(ErrorMessage = "UserIdentifier must be submitted")]
        public Guid? userIdentifier { get; set; }

        [Required(ErrorMessage = "RoomIdentifier must be submitted")]
        public Guid? roomIdentifier { get; set; }
    }
}
