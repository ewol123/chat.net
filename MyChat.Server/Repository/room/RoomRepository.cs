using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyChat.Domain.Model;
using MyChat.Domain.Repository;
using MyChat.Server.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace MyChat.Server.Repository.room
{
    public class RoomRepository: IRoomRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<RoomRepository> _logger;

        public RoomRepository(AppDbContext appDbContext, ILogger<RoomRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<List<Room>> FindAll()
        {
            try
            {
                return await _appDbContext.Rooms.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new List<Room>();
            }
        }

        public async Task<Room> FindById(Guid id)
        {
            try
            {
                return await _appDbContext.Rooms.SingleOrDefaultAsync(m => m.id == id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new Room();
            }
        }

        public async Task<Room> FindByIdentifier(Guid identifier)
        {
            try
            {
                return await _appDbContext.Rooms.SingleOrDefaultAsync(m => m.identifier == identifier);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new Room();
            }
        }

        public Task<bool> Remove(Room room)
        {
            try
            {
                _appDbContext.Rooms.Attach(room);
                var res = _appDbContext.Rooms.Remove(room);
                return Task.FromResult(res.State == EntityState.Deleted);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Task.FromResult(false);
            }
        }

        public async Task<bool> Save(Room room)
        {
            try
            {
                var res = await _appDbContext.Rooms.AddAsync(room);
                return res.State == EntityState.Added;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }
    }
}
