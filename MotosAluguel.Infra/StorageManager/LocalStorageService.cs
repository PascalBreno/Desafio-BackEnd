using MotosAluguel.Domain.Interfaces.StorageManager;

namespace MotosAluguel.Infra.StorageManager;

public class LocalStorageService : ILocalStorageService
{
    private readonly string _basePath;

    public LocalStorageService()
    {
        _basePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads/Cnhs");
        Directory.CreateDirectory(_basePath);
    }

    public async Task<string> SaveBase64ImageAsync(string base64String)
    {
        var data = base64String.Split(',');
        var mimeType = data[0].Replace("data:", "").Replace(";base64", "");

        var extension = mimeType == "image/png" ? ".png" : ".bmp";
        var fileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(_basePath, fileName);

        var fileBytes = Convert.FromBase64String(data[1]);
        await File.WriteAllBytesAsync(filePath, fileBytes);

        return filePath;
    }
}