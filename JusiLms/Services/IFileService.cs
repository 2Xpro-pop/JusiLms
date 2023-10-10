using Microsoft.AspNetCore.Components.Forms;

namespace JusiLms.Services;

public interface IFileService
{
    public Task<string> UploadFile(IBrowserFile browserFile);
    public Task RemoveFile(string file);
    public ValueTask<bool> FileExist(string file);
}
