using System;
using BauBlogApp.Shared.Utilities.Results.Abstract;
using BauBlogApp.Shared.Utilities.Results.ComplexTypes;

namespace BauBlogApp.Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result( ResultStatus resultStatus, string message)
        {

            ResultStatus = resultStatus;
            Message = message;
        }
        
        public Result( ResultStatus resultStatus, string message,Exception exception)
        {

            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }


       
        
        public ResultStatus ResultStatus { get; }
        
        public string Message { get; }
        
        public Exception Exception { get; }
        
        //Nasil kullanilir ?
        // new Result(ResultStatus.Error,"Islem Basarisiz Oldu", exception)
        
    }
}