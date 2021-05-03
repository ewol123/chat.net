using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyChat.Domain.Model;
namespace MyChat.Server.Hub
{
    public interface IChatClient
    {
        Task ChimeMeetingCreated(CreateChimeMeetingResponse response);
        Task JoinedChimeMeeting(JoinChimeMeetingResponse response);
        Task UserCreated(CreateUserResponse response);
        Task BrLeftRoom(DisconnectResponse response);
        Task Pong(PingResponse response);
        Task MessageCreated(CreateMessageResponse response);
        Task BrMessageCreated(CreateMessageResponse response);
        Task JoinedRoom(JoinRoomResponse response);
        Task BrJoinedRoom(JoinRoomResponse response);
        Task LeftRoom(LeaveRoomResponse response);
        Task BrLeftRoom(LeaveRoomResponse response);
    }
}
