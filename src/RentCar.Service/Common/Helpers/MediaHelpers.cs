using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Common.Helpers;

public class MediaHelpers
{
    public static string MakeImageName(string filename)
    {
        FileInfo fileInfo = new FileInfo(filename);
        var extension = fileInfo.Extension;
        var ImageName = "IMG" + Guid.NewGuid() + extension;
        return ImageName;
    }

    public static string[] GetImageExtension()
    {
        return new string[]
        {
            //JPG files
            ".jpg", ".jpeg",
            //Png files
            ".png",
            //Bitmap files
            ".bmp",
            //Svg files
            ".svg"
        };
    }
}
