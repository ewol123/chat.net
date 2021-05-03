using System;
using System.Collections.Generic;
using System.Text;
using MyChat.Domain.Error;
using Amazon.Chime.Model;
namespace MyChat.Domain.Model
{
    public class CreateChimeMeetingResponse: IResponse
    {
        public CreateMeetingResponse meetingResponse { get; set; }
        public CreateAttendeeResponse attendeeResponse { get; set; }

        public IEnumerable<ApplicationError> error { get; set; } 


    }
}