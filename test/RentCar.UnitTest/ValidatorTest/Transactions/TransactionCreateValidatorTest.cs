using RentCar.Service.Dtos.Transactions;
using RentCar.Service.Validators.Dtos.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.UnitTest.ValidatorTest.Transactions;

public class TransactionCreateValidatorTest
{
    [Theory]
    [InlineData("A")]
    [InlineData("AA")]
    [InlineData(" A       ")]
    [InlineData("           ")]
    [InlineData("jsajcasgvcsajb")]
    [InlineData("          2115   ")]

    public void ShouldReturnInValidDescription(string description)
    {
        TransactionCreateDto transactionCreateDto = new TransactionCreateDto();
        transactionCreateDto.CarId = 1;
        transactionCreateDto.RentalId = 1;
        transactionCreateDto.ClientId = 1;
        transactionCreateDto.Description = description;

        var validator = new TransactionCreateValidator();
        var result = validator.Validate(transactionCreateDto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("dskvbhsbvsdkvndjndsjvdshbvjhdb")]
    [InlineData("jhdsbvjhsdb hsdvuhsdiu usdvhsdui")]
    [InlineData("21215vd12 1512 dvdsvdsvsdvd")]
    [InlineData("dsvdsvdsvdsv dvsdvdsvds")]

    public void ShouldReturnValidDescription(string description)
    {
        TransactionCreateDto transactionCreateDto = new TransactionCreateDto();
        transactionCreateDto.CarId = 1;
        transactionCreateDto.RentalId = 1;
        transactionCreateDto.ClientId = 1;
        transactionCreateDto.Description = description;

        var validator = new TransactionCreateValidator();
        var result = validator.Validate(transactionCreateDto);
        Assert.True(result.IsValid);
    }
}
