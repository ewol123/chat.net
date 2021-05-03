using System;
using System.Collections.Generic;
using System.Text;
using MyChat.Domain.Model;
using System.Threading.Tasks;
namespace MyChat.Domain.Repository
{
    public interface IUserRepository
    {
        Task<User> FindById(Guid id);
        Task<User> FindBySocketId(string socketId);
        Task<User> FindRoomOfUserById(Guid id);
        Task<User> FindRoomOfUserBySocketId(string socketId);
        Task<List<User>> FindAllByRoomId(Guid roomId);
        Task<List<User>> FindAll();
        Task<bool> Save(User user);
        Task<bool> Remove(User user);
    }
}
