using System.Net;
using System.Text.Json.Serialization;

namespace MotosAluguel.Domain.Validators.Base;

public class OperationResult<T>
{
    public bool Success { get; private set; }
    public T? Data { get; private set; }
    public HttpStatusCode HttpStatusCode { get; private set; }
    public OperationMessage ErrorMessage { get; private set; }

    private OperationResult(
        bool success, 
        T? data = default,
        string? message = null,
        HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
    {
        Success = success;
        Data = data;
        ErrorMessage = new OperationMessage(message);
        HttpStatusCode = httpStatusCode;
    }

    public static OperationResult<T> Ok(T data)
        => new(true, data);

    public static OperationResult<T> Ok()
        => new(true);

    public static OperationResult<string> Ok(string message)
        => new(true,default, message);

    public static OperationResult<T> Fail(string error)
        => new(false, default, error);

    public static OperationResult<T> Fail(OperationResult operationResult)
        => new(false, default, operationResult.ErrorMessage.Message);

    public record OperationMessage(
        [property: JsonPropertyName("mensagem")] string Message);
}

public class OperationResult
{
    public bool Success { get; private set; }
    public HttpStatusCode HttpStatusCode { get; private set; }
    public OperationMessage ErrorMessage { get; private set; }

    private OperationResult(
        bool success,
        string message,
        HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
    {
        Success = success;
        ErrorMessage = new OperationMessage(message);
        HttpStatusCode = success ? HttpStatusCode.OK : httpStatusCode;
    }

    public static OperationResult Ok(string message) => new(true, message);
    public static OperationResult Ok() => new(true, null);
    public static OperationResult Fail(string error, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest) 
        => new(false, error, httpStatusCode);
    public record OperationMessage(string Message);
}
