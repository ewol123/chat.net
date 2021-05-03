using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyChat.Domain.Model;
using MyChat.Domain.Repository;
using MyChat.Server.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace MyChat.Server.Repository.message
{
    public class MessageRepository : IMessageRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly ILogger<MessageRepository> _logger;

        public MessageRepository(AppDbContext appDbContext, ILogger<MessageRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<List<Message>> FindAll()
        {
            try
            {
                return await _appDbContext.Messages.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new List<Message>();
            }
        }

        public async Task<List<Message>> FindAllByRoomId(Guid roomId)
        {
            try
            {
                return await _appDbContext.Messages
                    .Include(m => m.room)
                    .Include(m => m.user)
                    .Where(m => m.room.id == roomId)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new List<Message>();
            }
        }

        public async Task<Message> FindById(Guid id)
        {
            try
            {
                return await _appDbContext.Messages.SingleOrDefaultAsync(m => m.id == id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new Message();
            }
        }

        public Task<bool> Remove(Message message)
        {
            try
            {
                _appDbContext.Messages.Attach(message);
                var res = _appDbContext.Messages.Remove(message);
                return Task.FromResult(res.State == EntityState.Deleted);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Task.FromResult(false);
            }
        }

        public async Task<bool> Save(Message message)
        {
            try
            {
                var res = await _appDbContext.Messages.AddAsync(message);
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
