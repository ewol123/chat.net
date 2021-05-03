using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyChat.Domain.Model;

namespace MyChat.Domain.Repository
{
    public interface IMessageRepository
    {
        Task<Message> FindById(Guid id);
        Task<List<Message>> FindAllByRoomId(Guid roomId);
        Task<List<Message>> FindAll();
        Task<bool> Save(Message message);
        Task<bool> Remove(Message message);
    }
}