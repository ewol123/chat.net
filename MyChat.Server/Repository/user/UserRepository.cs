using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyChat.Domain.Model;
using MyChat.Domain.Repository;
using MyChat.Server.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace MyChat.Server.Repository.user
{
    public class UserRepository: IUserRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext appDbContext, ILogger<UserRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<List<User>> FindAll()
        {
            try
            {
                return await _appDbContext.Users.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new List<User>();
            }
        }

        public async Task<List<User>> FindAllByRoomId(Guid roomId)
        {
            try
            {
                return await _appDbContext.Users
                    .Where(u => u.room.id == roomId)
                    .Select(u => u)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new List<User>();
            }
        }

        public async Task<User> FindById(Guid id)
        {
            try
            {
                return await _appDbContext.Users.SingleOrDefaultAsync(u => u.id == id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new User();
            }
        }

        public async Task<User> FindBySocketId(string socketId)
        {
            try
            {
                return await _appDbContext.Users.SingleOrDefaultAsync(u => u.socketId == socketId);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new User();
            }
        }

        public async Task<User> FindRoomOfUserById(Guid id)
        {
            try
            {
                return await _appDbContext.Users
                    .Include(u => u.room)
                    .SingleOrDefaultAsync(u => u.id == id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new User();
            }
        }

        public async Task<User> FindRoomOfUserBySocketId(string socketId)
        {
            try
            {
                return await _appDbContext.Users
                    .Include(u => u.room)
                    .SingleOrDefaultAsync(u => u.socketId == socketId);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new User();
            }
        }

        public Task<bool> Remove(User user)
        {
            try
            {
                _appDbContext.Users.Attach(user);
                var res = _appDbContext.Users.Remove(user);
                return Task.FromResult(res.State == EntityState.Deleted);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Task.FromResult(false);
            }
        }

        public async Task<bool> Save(User user)
        {
            try
            {
                var res = await _appDbContext.Users.AddAsync(user);
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
