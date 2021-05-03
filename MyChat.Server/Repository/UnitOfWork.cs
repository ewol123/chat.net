using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyChat.Server.Infrastructure;
using MyChat.Domain.Repository;
namespace MyChat.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;


        public UnitOfWork(AppDbContext appDbContext)
        {
           _appDbContext = appDbContext;
        }

        public async Task Save()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
