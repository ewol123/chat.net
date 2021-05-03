using MyChat.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyChat.Domain.Repository;
using MyChat.Domain.Error;

namespace MyChat.Domain.Service.message
{
    public class MessageService : IMessageService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;

        public MessageService(IUnitOfWork unitOfWork, IUserRepository userRepository, IMessageRepository messageRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _messageRepository = messageRepository;
        }


        /**
        * Create a new message in a specific room.
        * This message can be seen by others in the
        * same room.
        */
        public async Task<CreateMessageResponse> CreateMessage(CreateMessageRequest payload)
        {
            try
            {
                var response = new CreateMessageResponse();


                User user = await _userRepository.FindRoomOfUserById((Guid)payload.userIdentifier);

                if (user == null)
                {
                    throw new ApplicationError("[MessageService.CreateMessage]", 1);
                }

                if(user.room == null)
                {
                    throw new ApplicationError("[MessageService.CreateMessage]", 2);
                }

                var model = new Message
                {
                    id = Guid.NewGuid(),
                    text = payload.text,
                    user = user,
                    room = user.room,
                    stamp = DateTime.Now
                };

                bool result = await _messageRepository.Save(model);

                if (!result)
                {
                    throw new ApplicationError("[MessageService.CreateMessage]", 3);
                }

                response.message = model;
                response.roomIdentifier = user.room.identifier;

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

