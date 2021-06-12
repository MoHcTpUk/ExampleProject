using System.Collections.Generic;

namespace ExampleProject.Identity.Models
{
    public class BaseResponse<T>
    {
        public bool Succeeded;
        public string Message { get; set; }
        public List<string> Errors;
        public T Data { get; set; }

        public BaseResponse()
        {
        }

        public BaseResponse(T data, string message = null)
        {
            Message = message;
            Data = data;
        }

        public BaseResponse(string message)
        {
            Message = message;
            Succeeded = false;
        }
    }
}
