using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Dtos.Auth;

public class VerifyDto
{
    public string PhoneNumber { get; set; } = string.Empty;

    public int Code { get; set; }
}
