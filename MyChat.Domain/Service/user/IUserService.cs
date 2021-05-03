using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyChat.Domain.Model;
namespace MyChat.Domain.Service.user
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUser(CreateUserRequest payload);
        Task<DisconnectResponse> Disconnect(DisconnectRequest payload);
    }
}
