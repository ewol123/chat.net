using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyChat.Domain.Model;
namespace MyChat.Domain.Service.message
{
    public interface IMessageService
    {
        Task<CreateMessageResponse> CreateMessage(CreateMessageRequest payload);
    }
}
