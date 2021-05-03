using MyChat.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyChat.Domain.Error
{
    public class ApplicationError: Exception
    {

        private Dictionary<int, string> _messages = new Dictionary<int, string>()
        {
            {1,"no user found"},
            {2,"user is not in any room"},
            {3,"model persistence failed"},
            {4, "an unexpected error happened. please contact the site administrator" }
        };

        public new string Message { get; set; }

        


        public ApplicationError(string title, int resultCode)
        {
            Source = title;
            HResult = resultCode;
            
            string value;
            bool hasValue = _messages.TryGetValue(resultCode, out value);
            if (hasValue)
            {
                Message = value;
            } else
            {
                Message = "result code not found";
            }
        }

        public static T GetError<T>(Exception e, string caller) where T : IResponse, new()
        {
            try
            {
                T errorResponse;
                if (e.GetType() == typeof(ApplicationError))
                {
                    var Error = new List<ApplicationError>() { (ApplicationError)e };
                    errorResponse = (T)Activator.CreateInstance(typeof(T));
                    errorResponse.error = Error;
                }
                else
                {
                    var Error = new List<ApplicationError>() { new ApplicationError(caller, 4) };
                    errorResponse = (T)Activator.CreateInstance(typeof(T));
                    errorResponse.error = Error;
                }

                return errorResponse;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}