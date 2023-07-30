using RentCar.Service.Dtos.Transactions;
using RentCar.Service.Validators.Dtos.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.UnitTest.ValidatorTest.Transactions;

public class TransactionUpdateValidatorTest
{
    [Theory]
    [InlineData("A")]
    [InlineData("AA")]
    [InlineData(" A       ")]
    [InlineData("           ")]
    [InlineData("jsajcasgvcsajb")]
    [InlineData("          2115   ")]

    public void ShouldReturnWrongDescription(string description)
    {
        var dto = new TransactionUpdateDto();
        dto.Description = description;

        var validator = new TransactionUpdateValidator();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("dskvbhsbvsdkvndjndsjvdshbvjhdb")]
    [InlineData("jhdsbvjhsdb hsdvuhsdiu usdvhsdui")]
    [InlineData("21215vd12 1512 dvdsvdsvsdvd")]
    [InlineData("dsvdsvdsvdsv dvsdvdsvds")]

    public void ShouldReturnTrueDescription(string description)
    {
        var dto = new TransactionUpdateDto();
        dto.Description = description;

        var validator = new TransactionUpdateValidator();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }
}
