using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.Api
{
    public class ApiResult : ApiResult<object>
    {
        public ApiResult()
        {
            IsSuccess = true;
        }

        public ApiResult(object data)
        {
            Data = data;
            IsSuccess = true;
        }

        public ApiResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public ApiResult(ErrorInfo error, bool isUnAuthorized = false)
        {
            Error = error;
            IsUnAuthorized = isUnAuthorized;
            IsSuccess = false;
        }
    }


    public class ApiResult<TData>
    {
        public TData Data { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsUnAuthorized { get; set; }
        public ErrorInfo Error { get; set; }

        public ApiResult()
        {
            IsSuccess = true;
        }

        public ApiResult(TData data)
        {
            Data = data;
            IsSuccess = true;
        }

        public ApiResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public ApiResult(ErrorInfo error, bool isUnAuthorized = false)
        {
            Error = error;
            IsUnAuthorized = isUnAuthorized;
            IsSuccess = false;
        }
    }
}
