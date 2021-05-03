using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MyChat.Domain.Model
{
    public class CreateChimeMeetingRequest
    {
        [Required(ErrorMessage = "UserIdentifier must be submitted")]
        public Guid? userIdentifier { get; set; }
    }
}