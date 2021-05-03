using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MyChat.Domain.Model;
using MyChat.Domain.Service.user;
using MyChat.Domain.Service.common;
using MyChat.Domain.Service.chime;
using MyChat.Domain.Service.message;
using MyChat.Domain.Service.room;

using MyChat.Domain.Error;
using System.ComponentModel.DataAnnotations;

namespace MyChat.Server.Hub
{
    public class ChatHub: Hub<IChatClient>
    {
        private readonly IUserService _userService;
        private readonly ICommonService _commonService;
        private readonly IChimeService _chimeService;
        private readonly IMessageService _messageService;
        private readonly IRoomService _roomService;

        private readonly ILogger<ChatHub> _logger;

        public ChatHub(
            ILogger<ChatHub> logger,
            IUserService userService,
            ICommonService commonService,
            IChimeService chimeService,
            IMessageService messageService,
            IRoomService roomService)
        {
            _logger = logger;
            _userService = userService;
            _commonService = commonService;
            _chimeService = chimeService;
            _messageService = messageService;
            _roomService = roomService;
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            try
            {
                await base.OnDisconnectedAsync(exception);

                var request = new DisconnectRequest();
                request.socketId = Context.ConnectionId;
                var response = await _userService.Disconnect(request);

                await Groups.RemoveFromGroupAsync(Context.ConnectionId, response.roomIdentifier.ToString());
                await Clients.OthersInGroup(response.roomIdentifier.ToString()).BrLeftRoom(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public async Task CreateUser(CreateUserRequest request)
        {
            try
            {
                request.socketId = Context.ConnectionId;

                var ctx = new ValidationContext(request);
                var results = new List<ValidationResult>();
                Validator.TryValidateObject(request, ctx, results, true);
                if (results.Count > 0)
                {
                    throw new ApplicationError("[CreateUser]", 4);
                }

                var response = await _userService.CreateUser(request);
                await Clients.Caller.UserCreated(response);
            }
            catch (Exception e)
            {
                var errorResponse = ApplicationError.GetError<CreateUserResponse>(e,"[CreateUser]");
                _logger.LogError(e.Message);
                await Clients.Caller.UserCreated(errorResponse);
            }
        }

        public async Task CreateChimeMeeting(CreateChimeMeetingRequest request) {
            try
            {
                var ctx = new ValidationContext(request);
                var results = new List<ValidationResult>();
                Validator.TryValidateObject(request, ctx, results, true);
                if (results.Count > 0)
                {
                    throw new ApplicationError("[CreateChimeMeeting]", 4);
                }

                var response = await _chimeService.CreateChimeMeeting(request);
                await Clients.Caller.ChimeMeetingCreated(response);
            }
            catch (Exception e)
            {
                var errorResponse = ApplicationError.GetError<CreateChimeMeetingResponse>(e, "[CreateChimeMeeting]");
                _logger.LogError(e.Message);
                await Clients.Caller.ChimeMeetingCreated(errorResponse);
            }
        }
        public async Task CreateMessage(CreateMessageRequest request) {
            try
            {
                var ctx = new ValidationContext(request);
                var results = new List<ValidationResult>();
                Validator.TryValidateObject(request, ctx, results, true);
                if (results.Count > 0)
                {
                    throw new ApplicationError("[CreateMessage]", 4);
                }

                var response = await _messageService.CreateMessage(request);
                await Clients.Caller.MessageCreated(response);
                await Clients.OthersInGroup(response.roomIdentifier.ToString()).BrMessageCreated(response);
            }
            catch (Exception e)
            {
                var errorResponse = ApplicationError.GetError<CreateMessageResponse>(e, "[CreateMessage]");
                _logger.LogError(e.Message);
                await Clients.Caller.MessageCreated(errorResponse);
            }
        }
        public async Task JoinChimeMeeting(JoinChimeMeetingRequest request) {
            try
            {
                var ctx = new ValidationContext(request);
                var results = new List<ValidationResult>();
                Validator.TryValidateObject(request, ctx, results, true);
                if (results.Count > 0)
                {
                    throw new ApplicationError("[JoinChimeMeeting]", 4);
                }

                var response = await _chimeService.JoinChimeMeeting(request);
                await Clients.Caller.JoinedChimeMeeting(response);
            }
            catch (Exception e)
            {
                var errorResponse = ApplicationError.GetError<JoinChimeMeetingResponse>(e, "[JoinChimeMeeting]");
                _logger.LogError(e.Message);
                await Clients.Caller.JoinedChimeMeeting(errorResponse);
            }
        }
        public async Task JoinRoom(JoinRoomRequest request) {
            try
            {
                var ctx = new ValidationContext(request);
                var results = new List<ValidationResult>();
                Validator.TryValidateObject(request, ctx, results, true);
                if (results.Count > 0)
                {
                    throw new ApplicationError("[JoinRoom]", 4);
                }

                var response = await _roomService.JoinRoom(request);

                await Groups.AddToGroupAsync(Context.ConnectionId, response.roomIdentifier.ToString());
                await Clients.Caller.JoinedRoom(response);

                // do not broadcast all the messages for already joined users.
                response.messages = null;
                await Clients.OthersInGroup(response.roomIdentifier.ToString()).BrJoinedRoom(response);
            }
            catch (Exception e)
            {
                var errorResponse = ApplicationError.GetError<JoinRoomResponse>(e, "[JoinRoom]");
                _logger.LogError(e.Message);
                await Clients.Caller.JoinedRoom(errorResponse);
            }
        }
        public async Task LeaveRoom(LeaveRoomRequest request) {
            try
            {
                var ctx = new ValidationContext(request);
                var results = new List<ValidationResult>();
                Validator.TryValidateObject(request, ctx, results, true);
                if (results.Count > 0)
                {
                    throw new ApplicationError("[LeaveRoom]", 4);
                }

                var response = await _roomService.LeaveRoom(request);
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, response.roomIdentifier.ToString());

                await Clients.OthersInGroup(response.roomIdentifier.ToString()).BrLeftRoom(response);

                //user who left the room does not care anymore about the others.
                response.users = null;
                await Clients.Caller.LeftRoom(response);
            }
            catch (Exception e)
            {
                var errorResponse = ApplicationError.GetError<JoinRoomResponse>(e, "[LeaveRoom]");
                _logger.LogError(e.Message);
                await Clients.Caller.JoinedRoom(errorResponse);
            }
        }
        public async Task Ping() {
            try
            {
                var response =  _commonService.Ping();
                await Clients.Caller.Pong(response);
            }
            catch (Exception e)
            {
                var errorResponse = new PingResponse() { status = "ERROR" };
                _logger.LogError(e.Message);
                await Clients.Caller.Pong(errorResponse);
            }
        }
    }
}
