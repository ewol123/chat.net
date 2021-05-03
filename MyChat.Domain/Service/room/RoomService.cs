using MyChat.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyChat.Domain.Repository;
using MyChat.Domain.Error;
using System.Linq;
namespace MyChat.Domain.Service.room
{
    public class RoomService : IRoomService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IRoomRepository _roomRepository;

        public RoomService(
            IUnitOfWork unitOfWork, 
            IUserRepository userRepository, 
            IMessageRepository messageRepository,
            IRoomRepository roomRepository
            )
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _messageRepository = messageRepository;
            _roomRepository = roomRepository;
        }

       /**
       * Join a room with it's identifier.
       * If the room does not exist create it
       * otherwise join.
       */
        public async Task<JoinRoomResponse> JoinRoom(JoinRoomRequest payload)
        {
            try
            {
                var response = new JoinRoomResponse();

                User user = await _userRepository.FindRoomOfUserById((Guid)payload.userIdentifier);

                if (user == null)
                {
                    throw new ApplicationError("[RoomService.JoinRoom]", 1);
                }

                var room = await _roomRepository.FindByIdentifier((Guid)payload.roomIdentifier);

                if (room == null)
                {
                    room = new Room();
                    room.id = Guid.NewGuid();
                    room.identifier = (Guid)payload.roomIdentifier;
                    room.users = new List<User> { user };

                    bool result = await _roomRepository.Save(room);

                    if (!result)
                    {
                        throw new ApplicationError("[RoomService.JoinRoom]", 3);
                    }
                }
                else
                {
                    room.users = await _userRepository.FindAllByRoomId(room.id);
                    room.users.Add(user);
                }

                response.roomIdentifier = room.identifier;
                response.users = room.users;
                response.messages = await _messageRepository.FindAllByRoomId(room.id);

                await _unitOfWork.Save();

                return response;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

       /**
       * Leave a room the user is currently in.
       */
        public async Task<LeaveRoomResponse> LeaveRoom(LeaveRoomRequest payload)
        {
            try
            {
                var response = new LeaveRoomResponse();

                User user = await _userRepository.FindRoomOfUserById((Guid)payload.userIdentifier);

                if (user == null)
                {
                    throw new ApplicationError("[RoomService.LeaveRoom]", 1);
                }

                if (user.room == null)
                {
                    throw new ApplicationError("[RoomService.LeaveRoom]", 2);
                }

                var roomUsers = await _userRepository.FindAllByRoomId(user.room.id);

                user.room.users = roomUsers.Where(roomUser => roomUser.id != payload.userIdentifier).ToList();

                response.roomIdentifier = user.room.identifier;
                response.users = user.room.users;

                await _unitOfWork.Save();

                return response;
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
