using System;
using System.Collections.Generic;
using System.Text;
using MyChat.Domain.Model;
using System.Threading.Tasks;
namespace MyChat.Domain.Service.chime
{
    public interface IChimeService
    {
        Task<CreateChimeMeetingResponse> CreateChimeMeeting(CreateChimeMeetingRequest payload);
        Task<JoinChimeMeetingResponse> JoinChimeMeeting(JoinChimeMeetingRequest payload);
    }
}