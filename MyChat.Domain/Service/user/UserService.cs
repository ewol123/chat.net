using MyChat.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyChat.Domain.Repository;
using MyChat.Domain.Error;
using System.Linq;
namespace MyChat.Domain.Service.user
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IRoomRepository _roomRepository;

        public UserService(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IRoomRepository roomRepository
            )
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _roomRepository = roomRepository;
        }

       /**
       * Create a new user
       * with the provided name.
       */
        public async Task<CreateUserResponse> CreateUser(CreateUserRequest payload)
        {
            try
            {
                var response = new CreateUserResponse();

                var user = new User() {
                    id = Guid.NewGuid(),
                    name = payload.name,
                    socketId = payload.socketId
                };

                bool result = await _userRepository.Save(user);

                if (!result)
                {
                    throw new ApplicationError("[UserService.CreateUser]", 3);
                }


                response.id = user.id;
                response.name = user.name;

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
        public async Task<DisconnectResponse> Disconnect(DisconnectRequest payload)
        {
            try
            {
                var response = new DisconnectResponse();

                User user = await _userRepository.FindRoomOfUserBySocketId(payload.socketId);

                if (user == null)
                {
                    throw new ApplicationError("[UserService.Disconnect]", 1);
                }

                if(user.room == null)
                {
                    throw new ApplicationError("[UserService.Disconnect]", 2);
                }

                var room = user.room;
                var users = await _userRepository.FindAllByRoomId(room.id);

                user.room = null;

                response.roomIdentifier = room.identifier;
                response.users = users.Where(
                  (roomUser) => roomUser.socketId != payload.socketId
                );

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
