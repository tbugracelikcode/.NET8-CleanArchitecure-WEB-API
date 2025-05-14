using System.Net;
using System.Text.Json.Serialization;

namespace CleanApp.Application
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }

        public List<string>? ErrorMessage { get; set; }
        [JsonIgnore]
        public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
        [JsonIgnore]
        public bool IsFail => !IsSuccess;
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }

        public string? UrlasCreated { get; set; }

        public static ServiceResult<T> Success(T data, HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult<T> { Data = data, Status = status };
        }

        public static ServiceResult<T> SuccessasCreated(T data, string UrlasCreated)
        {
            return new ServiceResult<T> { Data = data, Status = HttpStatusCode.Created, UrlasCreated = UrlasCreated };
        }

        public static ServiceResult<T> Fail(List<string> errorMessages, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>
            {
                ErrorMessage = errorMessages,
                Status = status
            };
        }

        public static ServiceResult<T> Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>
            {
                ErrorMessage = [errorMessage],
                Status = status
            };
        }
    }

    public class ServiceResult
    {

        public List<string>? ErrorMessage { get; set; }

        [JsonIgnore]
        public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
        [JsonIgnore]
        public bool IsFail => !IsSuccess;
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }

        public static ServiceResult Success( HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult {Status = status };
        }

        public static ServiceResult Fail(List<string> errorMessages, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult
            {
                ErrorMessage = errorMessages,
                Status = status
            };
        }

        public static ServiceResult Fail(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult
            {
                ErrorMessage = [errorMessage],
                Status = status
            };
        }
    }
}
