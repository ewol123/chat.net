using MyChat.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyChat.Domain.Service.common
{
    public class CommonService : ICommonService
    {
        public PingResponse Ping()
        {
            try
            {
                return new PingResponse();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
