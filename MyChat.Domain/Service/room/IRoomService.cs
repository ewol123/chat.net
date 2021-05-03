using System;
using System.Collections.Generic;
using System.Text;
using MyChat.Domain.Model;
using System.Threading.Tasks;

namespace MyChat.Domain.Service.room
{
    public interface IRoomService
    {
        Task<JoinRoomResponse> JoinRoom(JoinRoomRequest payload);
        Task<LeaveRoomResponse> LeaveRoom(LeaveRoomRequest payload);
    }
}