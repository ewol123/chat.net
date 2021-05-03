using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyChat.Domain.Repository
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}
