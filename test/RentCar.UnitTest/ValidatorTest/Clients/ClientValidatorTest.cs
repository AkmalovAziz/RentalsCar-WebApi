using Microsoft.AspNetCore.Http;
using RentCar.Service.Dtos.Clients;
using RentCar.Service.Validators.Dtos.Clients;
using System.Text;

namespace RentCar.UnitTest.ValidatorTest.Clients;

public class ClientValidatorTest
{
    [Theory]
    [InlineData("AA")]
    [InlineData("A")]
    [InlineData("electronic products, we sell an electronic products to our clients, we sell an electronic products to our clients")]
    public void ShouldReturnInValidFirstname(string firstname)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = firstname,
            LastName = "aaaaaaaa",
            PhoneNumber = "+998998545977",
            DriverLicense = "AD123456",
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("AA")]
    [InlineData("A")]
    [InlineData("electronic products, we sell an electronic products to our clients, we sell an electronic products to our clients")]
    public void ShouldReturnInValidLastname(string lastname)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = "Aziz",
            LastName = lastname,
            PhoneNumber = "+998998545977",
            DriverLicense = "AD123456",
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("998998545977")]
    [InlineData("+8998545977")]
    [InlineData("8545977")]
    [InlineData("+99899A8545977")]
    [InlineData("99 854 59 77")]
    [InlineData("998545977")]
    [InlineData("99 854-59-77")]

    public void ShouldReturnInValidPhonenumber(string phonenumber)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = "Aziz",
            LastName = "Akmalov",
            PhoneNumber = phonenumber,
            DriverLicense = "AD123456",
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }


    [Theory]
    [InlineData("123456v")]
    [InlineData("A123456V")]
    [InlineData("a123456V")]
    [InlineData("123456aa")]
    [InlineData("aa123456")]
    [InlineData("12345678")]
    [InlineData("12g45_78")]
    [InlineData("AA 123456")]
    public void ShouldReturnInValidDriverlicense(string license)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = "Aziz",
            LastName = "Akmalov",
            PhoneNumber = "+99899854577",
            DriverLicense = license,
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(dto);
        Assert.False(result.IsValid);
    }

    [Theory]
    [InlineData("AD123456")]
    [InlineData("AD124456")]
    [InlineData("AD103456")]
    [InlineData("BD123456")]
    [InlineData("AD123006")]
    [InlineData("AD003456")]
    [InlineData("AD123156")]

    public void ShouldReturnValidDriverlicense(string license)
    {
        byte[] byteImage = Encoding.UTF8.GetBytes("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s");
        IFormFile imageFile = new FormFile(new MemoryStream(byteImage), 0, byteImage.Length, "data", "file.jpg");
        ClientCreateDto dto = new ClientCreateDto()
        {
            FirstName = "Aziz",
            LastName = "Akmalov",
            PhoneNumber = "+998998545977",
            DriverLicense = license,
            IsMale = true,
            ImagePath = imageFile,
            Description = "we sell an electronic products to our clients"
        };
        var validator = new ClientCreateValidators();
        var result = validator.Validate(dto);
        Assert.True(result.IsValid);
    }

}
