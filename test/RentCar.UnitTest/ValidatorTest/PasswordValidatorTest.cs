using Microsoft.AspNetCore.Identity;
using RentCar.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.UnitTest.ValidatorTest;

public class PasswordValidatorTest
{
    [Theory]
    [InlineData("AAaa@@11")]
    [InlineData("Ac342334%234!")]
    [InlineData("kl3ngj#$%#Yhbdkjnfkgr034tjk43n")]
    [InlineData("jkr3bg4839akP@#32423greoernb")]
    [InlineData("bbBB##11$5")]
    [InlineData("Aa1___)%")]
    [InlineData("AAaa111.")]
    [InlineData("AAaa111,")]
    [InlineData("AAaa111^")]
    public void IsStrongPassword(string password)
    {
        var result = PasswordValidators.IsStrongPassword(password);
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("AAaa@@1")]
    [InlineData("AAaa!!@@")]
    [InlineData("aaaa@@11")]
    [InlineData("AAAA@@11")]
    [InlineData("AAAA@@bb")]
    [InlineData("AAAAbb11bb")]
    [InlineData("AAaa111 ")]
    [InlineData("AAAAAAAAAAA")]
    [InlineData("aaaaaaaaaaa")]
    [InlineData("99999999999")]
    [InlineData("@@@@@@@@@@@")]
    public void ShouldReturnWeakPassword(string password)
    {
        var result = PasswordValidators.IsStrongPassword(password);
        Assert.False(result.IsValid);
    }
}
