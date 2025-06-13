namespace MotosAluguel.Domain.Interfaces.StorageManager;

public interface ILocalStorageService
{
    Task<string> SaveBase64ImageAsync(string base64String);
}
