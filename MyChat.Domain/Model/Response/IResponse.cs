using MyChat.Domain.Error;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyChat.Domain.Model
{
    public interface IResponse
    {
            public IEnumerable<ApplicationError> error { get; set; }

    }
}
