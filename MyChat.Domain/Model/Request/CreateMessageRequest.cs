using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace MyChat.Domain.Model
{
    public class CreateMessageRequest
    {
        [Required(ErrorMessage = "UserIdentifier must be submitted")]
        public Guid? userIdentifier { get; set; }

        [Required(ErrorMessage = "Text must be submitted"), MinLength(1), MaxLength(255)]
        public string text { get; set; }

    }
}
