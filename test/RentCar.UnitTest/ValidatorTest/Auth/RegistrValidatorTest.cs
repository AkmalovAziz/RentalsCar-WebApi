using RentCar.Service.Dtos.Auth;
using RentCar.Service.Validators.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.UnitTest.ValidatorTest.Auth;

public class RegistrValidatorTest
{
    [Theory]
    [InlineData("a                               vhuivhfuhvufhvishuvhsvusivhisuvhfufuhsivhf")] 
    [InlineData("                                                                               ")]
    [InlineData("adhebebewfewfiewjfewuhfeuwfhewufhewufewuhvhghgjkl;jhjgdfghuioygfxfgchj")]
    public void ShouldReturnWrongFirstName(string firstname)
    {
        var dto = new RegistrDto();
        dto.FirstName = firstname;
        dto.LastName = "Akmalov";
        dto.PhoneNumber = "+998998545977";
        dto.Password = "AAAAAvdsbvhjb2121@@@@__";

        var validator = new RegistrValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("    ")]
    [InlineData("                         dvsdsbvsdgvsdgv                             ")]
    [InlineData("adhebebewfewfiewjfewuhfeuwfhewufhewufewuhvhghgjkl;jhjgdfghuioygfxfgchj")]
    [InlineData("165484316846531354613156d3213546531215156")]
    public void ShouldReturnWrongLastName(string lastname)
    {
        var dto = new RegistrDto();
        dto.FirstName = lastname;
        dto.LastName = "Akmalov";
        dto.PhoneNumber = "+998998545977";
        dto.Password = "AAAAAvdsbvhjb2121@@@@__";

        var validator = new RegistrValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }
}
