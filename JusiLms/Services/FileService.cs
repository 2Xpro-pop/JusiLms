using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;

namespace JusiLms.Services;

public class FileService : IFileService
{
    public const int MaxAllowedSize = 8 * 1024 * 1024;

    private readonly string _fullUploadFolderPath;
    private readonly string _uploadFolderPath;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileService(IWebHostEnvironment webHostEnvironment, IOptions<FileServiceOptions> options)
    {
        _webHostEnvironment = webHostEnvironment;
        _uploadFolderPath = options.Value.UploadFolderPath;
        _fullUploadFolderPath = Path.Combine(webHostEnvironment.WebRootPath, _uploadFolderPath);

        // Создать папку, если она не существует
        if (!Directory.Exists(_fullUploadFolderPath))
        {
            Directory.CreateDirectory(_fullUploadFolderPath);
        }
    }

    public async Task<string> UploadFile(IBrowserFile browserFile)
    {
        if (browserFile == null || browserFile.Size == 0)
        {
            throw new ArgumentException("Invalid file", nameof(browserFile));
        }

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(browserFile.Name);
        var filePath = Path.Combine(_webHostEnvironment.WebRootPath, _uploadFolderPath, fileName);

        using (var stream = browserFile.OpenReadStream(MaxAllowedSize))
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await stream.CopyToAsync(fileStream);
        }

        return Path.Combine(_uploadFolderPath, fileName);
    }

    public Task RemoveFile(string file)
    {
        var filePath = Path.Combine(_uploadFolderPath, file);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        return Task.CompletedTask;
    }

    public ValueTask<bool> FileExist(string file)
    {
        var filePath = Path.Combine(_uploadFolderPath, file);
        return new ValueTask<bool>(File.Exists(filePath));
    }
}