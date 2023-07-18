using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Exceptions.Files;

public class ImageNotFoundException : NotFoundExceptions
{
    public ImageNotFoundException()
    {
        this.TitleMessage = "Image not found";
    }
}
