using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using RentCar.Service.Common.Helpers;
using RentCar.Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Services.Common;

public class FileService : IFileService
{
    private readonly string IMAGE = "image";
    private readonly string MEDIA = "media";
    private readonly string AVATAR = "avatar";
    private readonly string ROOTPATH;

    public FileService(IWebHostEnvironment env)
    {
        ROOTPATH = env.WebRootPath;
    }

    public async Task<bool> DeleteImageAsync(string subpath)
    {
        string path = Path.Combine(ROOTPATH, subpath);
        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });
            return true;
        }
        else return false;
    }

    public async Task<string> UploadImageAsync(IFormFile image)
    {
        string newImageName = MediaHelpers.MakeImageName(image.FileName);
        string subpath = Path.Combine(MEDIA, IMAGE, newImageName);
        string path = Path.Combine(ROOTPATH, subpath);

        var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream);
        stream.Close();

        return subpath;
    }
}
