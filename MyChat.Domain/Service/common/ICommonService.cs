using System;
using System.Collections.Generic;
using System.Text;
using MyChat.Domain.Model;
namespace MyChat.Domain.Service.common
{
    public interface ICommonService
    {
        PingResponse Ping();
    }
}
