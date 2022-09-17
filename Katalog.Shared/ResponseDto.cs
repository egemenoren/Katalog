using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Katalog.Shared
{

    public class ResponseDto
    {
        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccessful { get; set; }

        public List<string> Errors { get; set; }


        public static ResponseDto Success(int statusCode)
        {
            return new ResponseDto { StatusCode = statusCode, IsSuccessful = true };
        }
        public static ResponseDto Fail(List<string> errors, int statusCode)
        {
            return new ResponseDto { Errors = errors, StatusCode = statusCode, IsSuccessful = false };
        }
        public static ResponseDto Fail(string error, int statusCode)
        {
            return new ResponseDto { Errors = new List<string> { error }, StatusCode = statusCode, IsSuccessful = false };
        }
        public static ResponseDto Fail()
        {
            return new ResponseDto {IsSuccessful = false };
        }
    }
    public class ResponseDto<T> : ResponseDto
    {
        public T Data { get; set; }

        
        public static ResponseDto<T> Success(T data,int statusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }
        public static ResponseDto<T> Fail(T data,List<string> errors, int statusCode)
        {
            return new ResponseDto<T> { Errors = errors, StatusCode = statusCode, IsSuccessful = false,Data=data };
        }
        public static ResponseDto<T> Fail(T data,string error, int statusCode)
        {
            return new ResponseDto<T> { Errors = new List<string> { error }, StatusCode = statusCode, IsSuccessful = false,Data=data };
        }


    }
}
