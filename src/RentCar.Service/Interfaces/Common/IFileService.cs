using Microsoft.AspNetCore.Http;

namespace RentCar.Service.Interfaces.Common;

public interface IFileService
{
    public Task<string> UploadImageAsync(IFormFile image);

    public Task<bool> DeleteImageAsync(string subpath);
}
