using System;
using BauBlogApp.Shared.Utilities.Results.ComplexTypes;

namespace BauBlogApp.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; } //Resultstatus.Success // ResultStatus.Error

        public string Message { get; }

        public Exception Exception { get; }
        
    }
}