using System.Net;
using System.Text.Json.Serialization;

namespace Services;

public class ServiceResult<T>
{
    public T? Data { get; set; }
    public List<string>? ErrorMessage { get; set; }
    [JsonIgnore] public bool IsSuccess => ErrorMessage is null || ErrorMessage?.Count is not 0;
    [JsonIgnore] public HttpStatusCode StatusCode { get; set; }

    public static ServiceResult<T> Success(T data, HttpStatusCode statusCode = HttpStatusCode.OK) => new() { Data = data, StatusCode = statusCode };
    public static ServiceResult<T> Fail(List<string> errorMesage, HttpStatusCode statusCode = HttpStatusCode.BadRequest) => new() { ErrorMessage = errorMesage, StatusCode = statusCode, };
    public static ServiceResult<T> Fail(string fail, HttpStatusCode statusCode = HttpStatusCode.BadRequest) => new() { ErrorMessage = [fail], StatusCode = statusCode };
}

public class ServiceResult
{
    public List<string>? ErrorMessage { get; set; }
    [JsonIgnore] public bool IsSuccess => ErrorMessage is null || ErrorMessage?.Count is not 0;
    [JsonIgnore] public HttpStatusCode StatusCode { get; set; }

    public static ServiceResult Success(HttpStatusCode statusCode = HttpStatusCode.OK) => new() { StatusCode = statusCode };
    public static ServiceResult Fail(List<string> errorMesage, HttpStatusCode statusCode = HttpStatusCode.BadRequest) => new() { ErrorMessage = errorMesage, StatusCode = statusCode, };
    public static ServiceResult Fail(string fail, HttpStatusCode statusCode = HttpStatusCode.BadRequest) => new() { ErrorMessage = [fail], StatusCode = statusCode };
}
