namespace MotosAluguel.Application.Commons;

public class OperationResult<T>
{
    public bool Success { get; private set; }
    public T? Data { get; private set; }
    public string? Error { get; private set; }

    private OperationResult(bool success, T? data = default, string? error = null)
    {
        Success = success;
        Data = data;
        Error = error;
    }

    public static OperationResult<T> Ok(T data)
        => new(true, data);

    public static OperationResult<T> Fail(string error)
        => new(false, default, error);
}