using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyChat.Domain.Model;

namespace MyChat.Domain.Repository
{
    public interface IRoomRepository
    {
        Task<Room> FindById(Guid id);
        Task<Room> FindByIdentifier(Guid identifier);
        Task<List<Room>> FindAll();
        Task<bool> Save(Room room);
        Task<bool> Remove(Room room);
    }
}
