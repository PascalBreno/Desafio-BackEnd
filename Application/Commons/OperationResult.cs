using System.Text.Json.Serialization;

namespace MotosAluguel.Application.Commons;

public class OperationResult<T>
{
    public bool Success { get; private set; }
    public T? Data { get; private set; }
    public OperationMessage Message { get; private set; }

    private OperationResult(bool success, T? data = default, string? message = null)
    {
        Success = success;
        Data = data;
        Message = new OperationMessage(message);
    }

    public static OperationResult<T> Ok(T data)
        => new(true, data);

    public static OperationResult<T> Ok()
        => new(true);

    public static OperationResult<string> Ok(string message)
        => new(true,default, message);

    public static OperationResult<T> Fail(string error)
        => new(false, default, error);

    public record OperationMessage(
        [property: JsonPropertyName("mensagem")] string Message);
}